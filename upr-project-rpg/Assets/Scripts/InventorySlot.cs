using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    
    public Image icon;
    public Button removeButton;
    Item item;
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.sprite;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot()
    {
        icon.enabled = false;
        icon.sprite = null;
        item = null;
        removeButton.interactable = false;
    }

    public void OnRemoveButtonClicked()
    {
        Inventory.instance.RemoveItem(item);
        
    }
    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
