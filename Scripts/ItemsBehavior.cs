using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemsBehavior : MonoBehaviour
{
    public void UsePotion(int health, int mana, int n)
    {
        PlayerStats newValues = InventoryCore.units[InventoryCore.selected];
        newValues.health += health;
        newValues.mana += mana;
        if (newValues.health > newValues.maxhealth) { newValues.health = newValues.maxhealth; }
        if (newValues.mana > newValues.maxmana) { newValues.mana = newValues.maxmana; }
        InventoryCore.units[InventoryCore.selected] = newValues;
        InventoryCore.items.RemoveAt(n);
    }

    public void EquipWeapon(int damage, int n)
    {
        if (InventoryCore.units[InventoryCore.selected].weapon.itemType == ItemType.Empty)
        {
            PlayerStats newValues = InventoryCore.units[InventoryCore.selected];
            newValues.weapon = InventoryCore.items[n];
            newValues.damage += damage;
            InventoryCore.units[InventoryCore.selected] = newValues;
            InventoryCore.items.RemoveAt(n);
        }
    }

    public void EquipArmor(int defense, int n)
    {
        if (InventoryCore.units[InventoryCore.selected].armor.itemType == ItemType.Empty)
        {
            PlayerStats newValues = InventoryCore.units[InventoryCore.selected];
            newValues.armor = InventoryCore.items[n];
            newValues.defense += defense;
            InventoryCore.units[InventoryCore.selected] = newValues;
            InventoryCore.items.RemoveAt(n);
        }
    }
}
