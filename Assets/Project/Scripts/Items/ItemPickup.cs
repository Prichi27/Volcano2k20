using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : ItemInteract
{
    public Item item;
    public GameObject pickupAnimation;
    internal override void Action()
    {
        Inventory.instance.Add(item);
        Instantiate(pickupAnimation, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

}
