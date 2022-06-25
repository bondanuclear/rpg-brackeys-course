using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    [SerializeField] Item item;
    Inventory inventory;
 
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picked up an item " + item.name);
        inventory = FindObjectOfType<Inventory>();

        if(inventory.checkCapacity())
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }
            
    }
}
