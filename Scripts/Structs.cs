using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct ItemsStats
{
    public ItemType itemType;
    public Sprite icon;
    public string description;
    public int health;
    public int mana;
    public int damage;
    public int defense;

    public ItemsStats(ItemType _itemType, Sprite _icon, string _description, int _health, int _mana, int _damage, int _defense){
        itemType = _itemType;
        icon = _icon;
        description = _description;
        health = _health;
        mana = _mana;
        damage = _damage;
        defense = _defense;
    }
}

[System.Serializable]
public struct PlayerStats
{
    public int health;
    public int mana;
    public int maxhealth;
    public int maxmana;
    public int damage;
    public int defense;
    public ItemsStats weapon;
    public ItemsStats armor;

    public PlayerStats(int _health, int _mana, int _maxhealth, int _maxmana, int _damage, int _defense, ItemsStats _weapon, ItemsStats _armor)
    {
        health = _health;
        mana = _mana;
        maxhealth = _maxhealth;
        maxmana = _maxmana;
        damage = _damage;
        defense = _defense;
        weapon = _weapon;
        armor = _armor;
    }
}

public enum ItemType
{
    Potion = 0,

    Weapon = 1,

    Armor = 2,

    Empty = 3
}

[System.Serializable]
public struct UnitUI
{
    public Image selected;
    public TextMeshProUGUI health;
    public TextMeshProUGUI mana;
    public Image weapon;
    public Image armor;
}