using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlot : MonoBehaviour
{
    public Image icon;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.sprite;
        icon.enabled = true;
    }
    public void ClearChestSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        item = null;
    }
    public void OnChestSlotClicked()
    {
        if(item != null)
        {
            Debug.LogAssertion(item == null);
            Inventory.instance.AddItem(item);
            Debug.LogAssertion(item == null);
            ChestInventory.instance.RemoveFromChest(item);
     
            
        }

       // ClearChestSlot();
            

    }
}
