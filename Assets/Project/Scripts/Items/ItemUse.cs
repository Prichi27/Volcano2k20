using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : ItemInteract
{
    internal override void Action()
    {

        foreach (Item item in items)
        {
            if (!Inventory.instance.CheckItem(item))
            {
                Debug.Log("Go collect items!");
                return;
            }

        }

        Debug.Log("I feel used");

    }
}
