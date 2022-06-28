using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    Inventory inventory;
    ChestInventory chest;
    [SerializeField] GameObject InventoryUI;
    [SerializeField] GameObject EquipmentUI;
    [SerializeField] Transform parentTransform;
    InventorySlot[] slots;
    [SerializeField] Transform chestParenTransform;
    ChestSlot[] chestSlots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        chest = ChestInventory.instance;
        slots = parentTransform.GetComponentsInChildren<InventorySlot>(true);
        chestSlots = chestParenTransform.GetComponentsInChildren<ChestSlot>(true);
        inventory.OnChangedCallback += UpdateUI;
        chest.onChestChanged += UpdateChestUI;
    }

    public void UpdateChestUI()
    {
        Debug.LogWarning("UPDATING CHEST UI");
        for (int i = 0; i < chestSlots.Length; i++)
        {
            if (i < chest.chestItems.Count)
            {
                chestSlots[i].AddItem(chest.chestItems[i]);

            }
            else chestSlots[i].ClearChestSlot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            OpenUI();
        }
    }

    public void OpenUI()
    {
        InventoryUI.SetActive(!InventoryUI.activeSelf);
        EquipmentUI.SetActive(!EquipmentUI.activeSelf);
    }

    public void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.itemList.Count)
            {
                slots[i].AddItem(inventory.itemList[i]);

            }                
            else slots[i].ClearSlot();
        }
        //Debug.Log("UPDATING UI");

    }
}
