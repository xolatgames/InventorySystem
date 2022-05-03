using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildBehavior : ClickableObject
{
    public PlayerStats stats;

    public string guildId;

    private void Update()
    {
        if (InventoryCore.chests.Contains(guildId))
        {
            Destroy(gameObject);
        }
    }

    public override void Click()
    {
        if (InventoryCore.AddUnit(stats))
        {
            InventoryCore.chests.Add(guildId);
        }
    }
}
