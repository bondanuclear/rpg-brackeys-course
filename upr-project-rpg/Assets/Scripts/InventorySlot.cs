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
    Item item;
    private void Start() {
        chestUI = GameObject.Find("ChestInventory");
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.sprite;
        icon.enabled = true;
        removeButton.interactable = true;
        if(chestUI.activeSelf == true)
        {
            stashButton.interactable = true;
        }
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
        ChestInventory.instance.AddToChest(item);
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
