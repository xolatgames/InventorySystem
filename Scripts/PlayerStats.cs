using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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