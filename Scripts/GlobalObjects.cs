using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalObjects : MonoBehaviour
{
    public static GlobalObjects instance = null;

    public List<ItemsStats> items = new List<ItemsStats>();

    public List<PlayerStats> units = new List<PlayerStats>();

    public List<string> chests = new List<string>();

    public int selected = 0;

    public int itemIconsCount;

    public int unitIconsCount;

    public bool showed = true;

    //Позиции игроков
    public static List<Transform> ptrans = new List<Transform>();

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public bool AddItem(ItemsStats item)
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

    public bool AddUnit(PlayerStats unit)
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
}
