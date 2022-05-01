using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCore : MonoBehaviour
{
    public List<ItemsStats> items = new List<ItemsStats>();

    public List<PlayerStats> units = new List<PlayerStats>();

    public int maxItems = 8;
}
