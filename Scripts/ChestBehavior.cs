using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : ClickableObject
{
    public ItemsStats item;

    public string chestId;

    private void Update()
    {
        if (GlobalObjects.instance.chests.Contains(chestId))
        {
            Destroy(gameObject);
        }
    }
    
    public override void Click()
    {
        foreach (InventoryCore i in GlobalObjects.inventories)
        {
            if (i.AddItem(item))
            {
                GlobalObjects.instance.chests.Add(chestId);
                break;
            }
        }
    }
}
