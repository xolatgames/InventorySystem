using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemsBehavior : MonoBehaviour
{
    public List<ItemsStats> items = new List<ItemsStats>();

    public List<PlayerStats> units = new List<PlayerStats>();

    public int selected = 0;

    public void UsePotion(int health, int mana, int damage, int defense, int n)
    {
        PlayerStats newValues = units[selected];
        newValues.health += health;
        newValues.mana += mana;
        newValues.damage += damage;
        newValues.defense += defense;
        if (newValues.health > (newValues.maxhealth + newValues.defense)) { newValues.health = newValues.maxhealth + newValues.defense; }
        if (newValues.mana > newValues.maxmana) { newValues.mana = newValues.maxmana; }
        units[selected] = newValues;
        items.RemoveAt(n);
    }

    public void EquipWeapon(int damage, int defense, int n)
    {
        if (selected < units.Count)
        {
            if (units[selected].weapon.itemType == ItemType.Empty)
            {
                PlayerStats newValues = units[selected];
                newValues.weapon = items[n];
                newValues.damage += damage;
                newValues.defense += defense;
                units[selected] = newValues;
                items.RemoveAt(n);
            }
        }
    }

    public void EquipArmor(int damage, int defense, int n)
    {
        if (selected < units.Count)
        {
            if (units[selected].armor.itemType == ItemType.Empty)
            {
                PlayerStats newValues = units[selected];
                newValues.armor = items[n];
                newValues.damage += damage;
                newValues.defense += defense;
                units[selected] = newValues;
                items.RemoveAt(n);
            }
        }
    }
}
