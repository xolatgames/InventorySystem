using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildBehavior : ClickableObject
{
    public PlayerStats stats;

    public string guildId;

    private void Update()
    {
        if (GlobalObjects.instance.chests.Contains(guildId))
        {
            Destroy(gameObject);
        }
    }

    public override void Click()
    {
        foreach (InventoryCore i in GlobalObjects.inventories)
        {
            if (i.AddUnit(stats))
            {
                GlobalObjects.instance.chests.Add(guildId);
                break;
            }
        }
    }
}
