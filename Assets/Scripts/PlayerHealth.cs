using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvincible = false;
    public float invicibilityFlashDelay = 0.15f;
    public float invicibilityTime = 2f;
    public SpriteRenderer graphics;
    public HealthBar healthBar;
    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Many instances in Playerhealth");
            return;
        }
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
            {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            if(currentHealth <=0)
            {
                Die();
                return;
            }
            StartCoroutine(InInvincibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }

    public void Die()
    {
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Die");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.TheCollider.enabled = false;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.TheCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        isInvincible = false; // a revoir
}

    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        healthBar.SetHealth(currentHealth);
    }


    public IEnumerator InInvincibilityFlash()
    {
        while(isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTime);
        isInvincible = false;
    }
}
