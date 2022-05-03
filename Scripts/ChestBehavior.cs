using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{
    public ItemsStats item;

    public string chestId;

    public float seeRange = 3;

    private void Update()
    {
        if (InventoryCore.chests.Contains(chestId))
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (!InventoryCore.showed)
        {
            if (Vector3.Distance(transform.position, PlayerMovement.ptrans.position) < seeRange)
            {
                if (InventoryCore.AddItem(item))
                {
                    InventoryCore.chests.Add(chestId);
                }
            }
        }
    }
}
