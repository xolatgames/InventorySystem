using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    public float seeRange = 3;

    private void OnMouseDown()
    {
        if (!GlobalObjects.inventories[0].showed)
        {
            foreach (Transform i in GlobalObjects.ptrans)
            {
                if (Vector3.Distance(transform.position, i.position) < seeRange)
                {
                    Click();
                    break;
                }
            }
        }
    }

    public abstract void Click();
}