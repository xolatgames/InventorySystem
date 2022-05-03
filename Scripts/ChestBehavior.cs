using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : ClickableObject
{
    public ItemsStats item;

    public string chestId;

    private void Update()
    {
        if (InventoryCore.chests.Contains(chestId))
        {
            Destroy(gameObject);
        }
    }
    
    public override void Click()
    {
        if (InventoryCore.AddItem(item))
        {
            InventoryCore.chests.Add(chestId);
        }
    }
}
