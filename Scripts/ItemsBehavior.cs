using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemsBehavior : MonoBehaviour
{
    public void UsePotion(int health, int mana, int damage, int defense, int n)
    {
        PlayerStats newValues = InventoryCore.units[InventoryCore.selected];
        newValues.health += health;
        newValues.mana += mana;
        newValues.damage += damage;
        newValues.defense += defense;
        if (newValues.health > (newValues.maxhealth + newValues.defense)) { newValues.health = newValues.maxhealth + newValues.defense; }
        if (newValues.mana > newValues.maxmana) { newValues.mana = newValues.maxmana; }
        InventoryCore.units[InventoryCore.selected] = newValues;
        InventoryCore.items.RemoveAt(n);
    }

    public void EquipWeapon(int damage, int defense, int n)
    {
        if (InventoryCore.selected < InventoryCore.units.Count)
        {
            if (InventoryCore.units[InventoryCore.selected].weapon.itemType == ItemType.Empty)
            {
                PlayerStats newValues = InventoryCore.units[InventoryCore.selected];
                newValues.weapon = InventoryCore.items[n];
                newValues.damage += damage;
                newValues.defense += defense;
                InventoryCore.units[InventoryCore.selected] = newValues;
                InventoryCore.items.RemoveAt(n);
            }
        }
    }

    public void EquipArmor(int damage, int defense, int n)
    {
        if (InventoryCore.selected < InventoryCore.units.Count)
        {
            if (InventoryCore.units[InventoryCore.selected].armor.itemType == ItemType.Empty)
            {
                PlayerStats newValues = InventoryCore.units[InventoryCore.selected];
                newValues.armor = InventoryCore.items[n];
                newValues.damage += damage;
                newValues.defense += defense;
                InventoryCore.units[InventoryCore.selected] = newValues;
                InventoryCore.items.RemoveAt(n);
            }
        }
    }
}
