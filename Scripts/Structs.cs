using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ItemsStats
{
    public ItemType itemType;
    public Image icon;
    public string description;
    public int health;
    public int mana;
    public int damage;
    public int defense;

    public ItemsStats(ItemType xitemType,Image xicon, string xdescription, int xhealth, int xmana, int xdamage, int xdefense){
        itemType = xitemType;
        icon = xicon;
        description = xdescription;
        health = xhealth;
        mana = xmana;
        damage = xdamage;
        defense = xdefense;
    }
}

[System.Serializable]
public struct PlayerStats
{
    public bool hasUnit;
    public int health;
    public int mana;
    public int maxhealth;
    public int maxmana;
    public int damage;
    public int defense;
    public ItemsStats weapon;
    public ItemsStats armor;

    public PlayerStats(bool xhasUnit, int xhealth, int xmana, int xmaxhealth, int xmaxmana, int xdamage, int xdefense, ItemsStats xweapon, ItemsStats xarmor)
    {
        hasUnit = xhasUnit;
        health = xhealth;
        mana = xmana;
        maxhealth = xmaxhealth;
        maxmana = xmaxmana;
        damage = xdamage;
        defense = xdefense;
        weapon = xweapon;
        armor = xarmor;
    }
}

public enum ItemType
{
    Potion = 0,

    Weapon = 1,

    Armor = 2
}
