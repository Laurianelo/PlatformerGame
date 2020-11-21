using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public static AudioManager instance;
    public AudioMixerGroup SoundEffectMixer;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Many instances in AudioManager");
            return;
        }
        instance = this;
    }


    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayNextSong();

        }
    }

    private void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }


    //to fix probleme with audio mixer when the object is deleted
    public AudioSource PlayClipAt(AudioClip sound, Vector3 pos)
    {
        GameObject temp = new GameObject("TempSound");
        temp.transform.position = pos;
        AudioSource audioSource = temp.AddComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.outputAudioMixerGroup = SoundEffectMixer;
        audioSource.Play();
        Destroy(temp, sound.length);
        return audioSource;
    }
}
