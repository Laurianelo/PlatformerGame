﻿using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string nameItem;
    public string description;
    public int price;
    public Sprite img;
    public int hpGiven;
    public int speedGiven;
    public float speedDuration;
 
}
