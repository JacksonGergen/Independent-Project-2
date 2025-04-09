using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Loot
{
    public string itemName;
    public int rarity;

    public Loot(string name, int rarity)
    {
        this.itemName = name;
        this.rarity = rarity;
    }
}
