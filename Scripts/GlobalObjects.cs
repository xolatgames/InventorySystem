using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalObjects : MonoBehaviour
{
    public static GlobalObjects instance = null;

    public List<string> chests = new List<string>();

    //Позиции игроков
    public static List<Transform> ptrans = new List<Transform>();

    public static List<InventoryCore> inventories = new List<InventoryCore>();

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
}
