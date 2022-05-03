using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildBehavior : MonoBehaviour
{
    public PlayerStats stats;

    public string guildId;

    public float seeRange = 3;

    private void Update()
    {
        if (InventoryCore.chests.Contains(guildId))
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
                if (InventoryCore.AddUnit(stats))
                {
                    InventoryCore.chests.Add(guildId);
                }
            }
        }
    }
}
