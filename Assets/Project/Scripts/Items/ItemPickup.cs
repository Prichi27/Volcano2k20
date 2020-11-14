using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : ItemInteract
{
    public Item item;
    internal override void Action()
    {
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
