using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemIDs;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemID itemID = ItemID.undecided;
    [SerializeField] private Sprite itemSprite = null;

    private int quantity = 0;

    public ItemID GetID() { return itemID; }

    protected virtual void Awake()
    {
        quantity = 0;
    }
    public abstract void Activate();
}
