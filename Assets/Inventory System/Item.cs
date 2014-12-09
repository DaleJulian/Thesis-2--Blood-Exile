using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item
{

    public string itemName;
    public int itemID;
    public Texture2D itemIcon;
    public string itemDescription;
    public ItemType itemType;
    public Rarity rarity;

    //stats
    public float minimumDamage, maxDamage;
    public float movementSpeed;
    public float armor;

    //consumable stats
    public float duration;
    public float HPperSec;
    public float MPperSec;

    public enum ItemType
    {
        Weapon,
        Head,
        Arms,
        Torso,
        Leg,
        Feet,
        Accessory,
        SkillScroll,
        Consumable
    }
    public enum Rarity
    {
        Common,
        Rare,
        Ancient,
        Legendary,
        Godlike
    }
    public Item(string name, int id, Texture2D icon, string desc, ItemType _itemType, Rarity _rarity)
    {
        itemName = name;
        itemID = id;
        icon = Resources.Load<Texture2D>("Textures/Inventory Icons/" + itemName);
        itemDescription = desc;
        itemType = _itemType;
        rarity = _rarity;
    }

    void Start()
    {
        itemIcon = Resources.Load<Texture2D>("Textures/Inventory Icons/" + itemName);
        
    }
	
	
	
}
