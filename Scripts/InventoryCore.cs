using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Только Инвентарь игрока
public class InventoryCore : ItemsBehavior
{
    public List<Image> itemIcons;

    public List<UnitUI> unitIcons;

    public TextMeshProUGUI description;

    public Sprite unitDeselected;

    public Sprite unitSelected;

    public Sprite unknown;

    public List<GameObject> showedObjects;

    private void Update()
    {
        GlobalObjects.instance.itemIconsCount = itemIcons.Count;
        GlobalObjects.instance.unitIconsCount = unitIcons.Count;

        for (int i = 0; i < itemIcons.Count; i++)
        {
            itemIcons[i].sprite = unknown;
        }

        for (int i = 0; i < GlobalObjects.instance.items.Count; i++)
        {
            if (itemIcons[i] != null)
            {
                itemIcons[i].sprite = GlobalObjects.instance.items[i].icon;
            }
        }

        for (int i = 0; i < unitIcons.Count; i++)
        {
            unitIcons[i].weapon.sprite = unknown;
            unitIcons[i].armor.sprite = unknown;
            unitIcons[i].selected.sprite = unitDeselected;
            unitIcons[i].health.text = "EMPTY";
            unitIcons[i].mana.text = "EMPTY";
            unitIcons[i].damage.text = "EMPTY";
        }

        for (int i = 0; i < GlobalObjects.instance.units.Count; i++)
        {
            if (unitIcons[i].selected != null)
            {
                unitIcons[i].weapon.sprite = GlobalObjects.instance.units[i].weapon.icon;
                unitIcons[i].armor.sprite = GlobalObjects.instance.units[i].armor.icon;
                unitIcons[i].health.text = "HP: " + GlobalObjects.instance.units[i].health + "/" + (GlobalObjects.instance.units[i].maxhealth + GlobalObjects.instance.units[i].defense);
                unitIcons[i].mana.text = "MP: " + GlobalObjects.instance.units[i].mana + "/" + GlobalObjects.instance.units[i].maxmana;
                unitIcons[i].damage.text = "Dam: " + GlobalObjects.instance.units[i].damage;
            }
        }

        if (GlobalObjects.instance.units.Count > 0)
        {
            unitIcons[GlobalObjects.instance.selected].selected.sprite = unitSelected;
        }
    }

    public void Save()
    {
        string path = Path.Combine(Application.dataPath, "Save.sav");

        SavingStats stats = new SavingStats
        {
            items = GlobalObjects.instance.items,
            units = GlobalObjects.instance.units,
            chests = GlobalObjects.instance.chests
        };

        File.WriteAllText(path, JsonUtility.ToJson(stats));
    }

    public void Load()
    {
        string path = Path.Combine(Application.dataPath, "Save.sav");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SavingStats stats = JsonUtility.FromJson<SavingStats>(json);

            GlobalObjects.instance.items = stats.items;

            GlobalObjects.instance.units = stats.units;

            GlobalObjects.instance.chests = stats.chests;
        }
    }

    public void LookDescription(int n)
    {
        if (GlobalObjects.instance.items.Count > n)
        {
            description.text = GlobalObjects.instance.items[n].description;
        }
    }

    public void ClickItem(int n)
    {
        if (GlobalObjects.instance.items.Count > n)
        {
            switch (GlobalObjects.instance.items[n].itemType)
            {
                case ItemType.Potion:
                    UsePotion(GlobalObjects.instance.items[n].health, GlobalObjects.instance.items[n].mana, GlobalObjects.instance.items[n].damage, GlobalObjects.instance.items[n].defense, n);
                    break;

                case ItemType.Weapon:
                    EquipWeapon(GlobalObjects.instance.items[n].damage, GlobalObjects.instance.items[n].defense, n);
                    break;

                case ItemType.Armor:
                    EquipArmor(GlobalObjects.instance.items[n].damage, GlobalObjects.instance.items[n].defense, n);
                    break;
            }
        }
    }

    public void ClickWeapon (int n)
    {
        if (GlobalObjects.instance.units.Count > n)
        {
            if (GlobalObjects.instance.units[n].weapon.itemType != ItemType.Empty)
            {
                if (GlobalObjects.instance.AddItem(GlobalObjects.instance.units[n].weapon))
                {
                    PlayerStats newValues = GlobalObjects.instance.units[n];
                    newValues.damage -= newValues.weapon.damage;
                    newValues.defense -= newValues.weapon.defense;
                    if (newValues.health > (newValues.maxhealth + newValues.defense)) { newValues.health = newValues.maxhealth + newValues.defense; }
                    newValues.weapon = new ItemsStats(ItemType.Empty, unknown, "", 0, 0, 0, 0);
                    GlobalObjects.instance.units[n] = newValues;
                }
            }
        }
    }

    public void ClickArmor(int n)
    {
        if (GlobalObjects.instance.units.Count > n)
        {
            if (GlobalObjects.instance.units[n].armor.itemType != ItemType.Empty)
            {
                if (GlobalObjects.instance.AddItem(GlobalObjects.instance.units[n].armor))
                {
                    PlayerStats newValues = GlobalObjects.instance.units[n];
                    newValues.damage -= newValues.armor.damage;
                    newValues.defense -= newValues.armor.defense;
                    if (newValues.health > (newValues.maxhealth + newValues.defense)) { newValues.health = newValues.maxhealth + newValues.defense; }
                    newValues.armor = new ItemsStats(ItemType.Empty, unknown, "", 0, 0, 0, 0);
                    GlobalObjects.instance.units[n] = newValues;
                }
            }
        }
    }

    public void ChangeUnit(int n)
    {
        GlobalObjects.instance.selected = n;
    }

    public void ShownHide()
    {
        if (GlobalObjects.instance.showed)
        {
            foreach (GameObject i in showedObjects)
            {
                i.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject i in showedObjects)
            {
                i.SetActive(true);
            }
        }

        GlobalObjects.instance.showed = !GlobalObjects.instance.showed;
    }
}
