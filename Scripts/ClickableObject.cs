using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    public float seeRange = 3;

    private void OnMouseDown()
    {
        if (!InventoryCore.showed)
        {
            if (Vector3.Distance(transform.position, PlayerMovement.ptrans.position) < seeRange)
            {
                Click();
            }
        }
    }

    public abstract void Click();
}