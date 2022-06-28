using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    
    public Image icon;
    public Button removeButton;
    public Button stashButton;
    GameObject chestUI;
    bool isChestUIActive = false;
    Item item;
    
    
    private void Update() {
        chestUI = GameObject.FindGameObjectWithTag("Chest");
        if(chestUI != null)
        {
            if (chestUI.activeSelf == true)
            {
                //Debug.LogWarning("ACTIVE SELF CHANGED");
                isChestUIActive = true;
            }
        }
       
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.sprite;
        icon.enabled = true;
        removeButton.interactable = true;  
        stashButton.interactable = true;
      
    }
    public void ClearSlot()
    {
        icon.enabled = false;
        icon.sprite = null;
        item = null;
        removeButton.interactable = false;
        stashButton.interactable = false;
    }

    public void OnRemoveButtonClicked()
    {
        Inventory.instance.RemoveItem(item);
        
    }
    public void OnStashButtonClicked()
    {
        if(isChestUIActive == true)
        {
            ChestInventory.instance.AddToChest(item);
            Inventory.instance.RemoveItem(item);
        }
        
    }
    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
