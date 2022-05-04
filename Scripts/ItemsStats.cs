using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public ItemsStats(ItemType _itemType, Sprite _icon, string _description, int _health, int _mana, int _damage, int _defense)
    {
        itemType = _itemType;
        icon = _icon;
        description = _description;
        health = _health;
        mana = _mana;
        damage = _damage;
        defense = _defense;
    }
}