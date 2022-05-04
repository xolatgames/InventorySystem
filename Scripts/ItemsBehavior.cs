using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemsBehavior : MonoBehaviour
{
    public void UsePotion(int health, int mana, int damage, int defense, int n)
    {
        PlayerStats newValues = GlobalObjects.instance.units[GlobalObjects.instance.selected];
        newValues.health += health;
        newValues.mana += mana;
        newValues.damage += damage;
        newValues.defense += defense;
        if (newValues.health > (newValues.maxhealth + newValues.defense)) { newValues.health = newValues.maxhealth + newValues.defense; }
        if (newValues.mana > newValues.maxmana) { newValues.mana = newValues.maxmana; }
        GlobalObjects.instance.units[GlobalObjects.instance.selected] = newValues;
        GlobalObjects.instance.items.RemoveAt(n);
    }

    public void EquipWeapon(int damage, int defense, int n)
    {
        if (GlobalObjects.instance.selected < GlobalObjects.instance.units.Count)
        {
            if (GlobalObjects.instance.units[GlobalObjects.instance.selected].weapon.itemType == ItemType.Empty)
            {
                PlayerStats newValues = GlobalObjects.instance.units[GlobalObjects.instance.selected];
                newValues.weapon = GlobalObjects.instance.items[n];
                newValues.damage += damage;
                newValues.defense += defense;
                GlobalObjects.instance.units[GlobalObjects.instance.selected] = newValues;
                GlobalObjects.instance.items.RemoveAt(n);
            }
        }
    }

    public void EquipArmor(int damage, int defense, int n)
    {
        if (GlobalObjects.instance.selected < GlobalObjects.instance.units.Count)
        {
            if (GlobalObjects.instance.units[GlobalObjects.instance.selected].armor.itemType == ItemType.Empty)
            {
                PlayerStats newValues = GlobalObjects.instance.units[GlobalObjects.instance.selected];
                newValues.armor = GlobalObjects.instance.items[n];
                newValues.damage += damage;
                newValues.defense += defense;
                GlobalObjects.instance.units[GlobalObjects.instance.selected] = newValues;
                GlobalObjects.instance.items.RemoveAt(n);
            }
        }
    }
}
