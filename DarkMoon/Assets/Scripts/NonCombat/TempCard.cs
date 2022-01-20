using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClassType
{
    Mage,
    Priest,
    Rogue,
    Warrior,
    Normal
}

[System.Serializable]
public class TempCard
{
    public ClassType class_type;
    public string item_name;
    public Sprite item_image;
    public int item_price;
}
