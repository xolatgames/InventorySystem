using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct UnitUI
{
    public Image selected;
    public TextMeshProUGUI health;
    public TextMeshProUGUI mana;
    public TextMeshProUGUI damage;
    public Image weapon;
    public Image armor;
}