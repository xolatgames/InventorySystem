using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCore : MonoBehaviour
{
    public static List<ItemsStats> items = new List<ItemsStats>();

    public static List<PlayerStats> units = new List<PlayerStats>();

    public static List<string> chests = new List<string>();

    public List<Image> itemIcons;

    public List<UnitUI> unitIcons;

    public Sprite unitDeselected;

    public Sprite unitSelected;

    public Sprite unknown;

    public int selected = 0;

    private void Start()
    {
        units.Add(new PlayerStats(12, 0, 12, 50, 0, 0, new ItemsStats(ItemType.Empty, unknown, "", 0, 0, 0, 0), new ItemsStats(ItemType.Empty, unknown, "", 0, 0, 0, 0)));
    }

    private void Update()
    {
        for (int i = 0; i < itemIcons.Count; i++)
        {
            itemIcons[i].sprite = unknown;
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (itemIcons[i])
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
        }

        if (units.Count > 0)
        {
            for (int i = 0; i < units.Count; i++)
            {
                if (unitIcons[i].selected)
                {
                    unitIcons[i].weapon.sprite = units[i].weapon.icon;
                    unitIcons[i].armor.sprite = units[i].armor.icon;
                    unitIcons[i].health.text = "HP: " + units[i].health + "/" + units[i].maxhealth;
                    unitIcons[i].mana.text = "MP: " + units[i].mana + "/" + units[i].maxmana;
                }
            }

            unitIcons[selected].selected.sprite = unitSelected;
        }
    }

    public static void Save()
    {
        string path = Path.Combine(Application.dataPath, "Items.sav");
        File.WriteAllText(path, JsonUtility.ToJson(items));
        path = Path.Combine(Application.dataPath, "Units.sav");
        File.WriteAllText(path, JsonUtility.ToJson(units));
        path = Path.Combine(Application.dataPath, "Chests.sav");
        File.WriteAllText(path, JsonUtility.ToJson(chests));
    }

    public static void Load()
    {
        string path = Path.Combine(Application.dataPath, "Items.sav");
        if (File.Exists(path))
        {
            items = JsonUtility.FromJson<List<ItemsStats>>(File.ReadAllText(path));
        }
        path = Path.Combine(Application.dataPath, "Units.sav");
        if (File.Exists(path))
        {
            units = JsonUtility.FromJson<List<PlayerStats>>(File.ReadAllText(path));
        }
        path = Path.Combine(Application.dataPath, "Chests.sav");
        if (File.Exists(path))
        {
            chests = JsonUtility.FromJson<List<string>>(File.ReadAllText(path));
        }
    }
}
