using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    [SerializeField] Item item;
    
 
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picked up an item " + item.name);
        

        if(Inventory.instance.checkCapacity())
        {

            Inventory.instance.AddItem(item);
            Destroy(gameObject);
        }
            
    }
}
