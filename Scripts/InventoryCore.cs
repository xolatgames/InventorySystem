using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Только Инвентарь игрока
public class InventoryCore : ItemsBehavior
{
    public static List<ItemsStats> items = new List<ItemsStats>();

    public static List<PlayerStats> units = new List<PlayerStats>();

    public static List<string> chests = new List<string>();

    public List<Image> itemIcons;

    public List<UnitUI> unitIcons;

    public TextMeshProUGUI description;

    public Sprite unitDeselected;

    public Sprite unitSelected;

    public Sprite unknown;

    public static int selected = 0;

    public static int itemIconsCount;

    public static int unitIconsCount;

    public static bool showed = true;

    public List<GameObject> showedObjects;

    //Позиции игроков
    public static List<Transform> ptrans = new List<Transform>();

    private void Start()
    {
        units.Add(new PlayerStats(1, 0, 18, 50, 0, 0, new ItemsStats(ItemType.Empty, unknown, "", 0, 0, 0, 0), new ItemsStats(ItemType.Empty, unknown, "", 0, 0, 0, 0)));
    }

    private void Update()
    {
        itemIconsCount = itemIcons.Count;
        unitIconsCount = unitIcons.Count;

        for (int i = 0; i < itemIcons.Count; i++)
        {
            itemIcons[i].sprite = unknown;
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (itemIcons[i] != null)
            {
                itemIcons[i].sprite = items[i].icon;
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

        for (int i = 0; i < units.Count; i++)
        {
            if (unitIcons[i].selected != null)
            {
                unitIcons[i].weapon.sprite = units[i].weapon.icon;
                unitIcons[i].armor.sprite = units[i].armor.icon;
                unitIcons[i].health.text = "HP: " + units[i].health + "/" + (units[i].maxhealth + +units[i].defense);
                unitIcons[i].mana.text = "MP: " + units[i].mana + "/" + units[i].maxmana;
                unitIcons[i].damage.text = "Dam: " + units[i].damage;
            }
        }

        if (units.Count > 0)
        {
            unitIcons[selected].selected.sprite = unitSelected;
        }
    }

    public static void Save()
    {
        string path = Path.Combine(Application.dataPath, "Save.sav");

        SavingStats stats = new SavingStats
        {
            items = InventoryCore.items,
            units = InventoryCore.units,
            chests = InventoryCore.chests
        };

        File.WriteAllText(path, JsonUtility.ToJson(stats));
    }

    public static void Load()
    {
        string path = Path.Combine(Application.dataPath, "Save.sav");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SavingStats stats = JsonUtility.FromJson<SavingStats>(json);

            InventoryCore.items = stats.items;

            InventoryCore.units = stats.units;

            InventoryCore.chests = stats.chests;
        }
    }

    public void LookDescription(int n)
    {
        if (items.Count > n)
        {
            description.text = items[n].description;
        }
    }

    public void ClickItem(int n)
    {
        if (items.Count > n)
        {
            switch (items[n].itemType)
            {
                case ItemType.Potion:
                    UsePotion(items[n].health, items[n].mana, items[n].damage, items[n].defense, n);
                    break;

                case ItemType.Weapon:
                    EquipWeapon(items[n].damage, items[n].defense, n);
                    break;

                case ItemType.Armor:
                    EquipArmor(items[n].damage, items[n].defense, n);
                    break;
            }
        }
    }

    public static bool AddItem(ItemsStats item)
    {
        if (items.Count < itemIconsCount)
        {
            items.Add(item);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ClickWeapon (int n)
    {
        if (units.Count > n)
        {
            if (units[n].weapon.itemType != ItemType.Empty)
            {
                if (AddItem(units[n].weapon))
                {
                    PlayerStats newValues = units[n];
                    newValues.damage -= newValues.weapon.damage;
                    newValues.defense -= newValues.weapon.defense;
                    if (newValues.health > (newValues.maxhealth + newValues.defense)) { newValues.health = newValues.maxhealth + newValues.defense; }
                    newValues.weapon = new ItemsStats(ItemType.Empty, unknown, "", 0, 0, 0, 0);
                    units[n] = newValues;
                }
            }
        }
    }

    public void ClickArmor(int n)
    {
        if (units.Count > n)
        {
            if (units[n].armor.itemType != ItemType.Empty)
            {
                if (AddItem(units[n].armor))
                {
                    PlayerStats newValues = units[n];
                    newValues.damage -= newValues.armor.damage;
                    newValues.defense -= newValues.armor.defense;
                    if (newValues.health > (newValues.maxhealth + newValues.defense)) { newValues.health = newValues.maxhealth + newValues.defense; }
                    newValues.armor = new ItemsStats(ItemType.Empty, unknown, "", 0, 0, 0, 0);
                    units[n] = newValues;
                }
            }
        }
    }

    public static bool AddUnit(PlayerStats unit)
    {
        if (units.Count < unitIconsCount)
        {
            units.Add(unit);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeUnit(int n)
    {
        selected = n;
    }

    public void ShownHide()
    {
        if (showed)
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

        showed = !showed;
    }
}
