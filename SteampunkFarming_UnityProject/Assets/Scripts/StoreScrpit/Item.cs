using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public enum ItemType {
        appleSeed,
        blueberrySeed,
        potato
    }

    public static int GetCost(ItemType itemType) 
    {
        switch (itemType) 
        {
        default:
        case ItemType.appleSeed:              return 200;
        case ItemType.blueberrySeed:          return 100;
        case ItemType.potato:                 return 50;
        }
    }
    
    public static Sprite GetSprite(ItemType itemType) 
    {
        switch (itemType) 
        {
        default:
        case ItemType.appleSeed:       return GameAssets.i.s_appleSeed;
        case ItemType.blueberrySeed:    return GameAssets.i.s_blueberrySeed;
        case ItemType.potato:           return GameAssets.i.s_potato;
        }
    }

}
