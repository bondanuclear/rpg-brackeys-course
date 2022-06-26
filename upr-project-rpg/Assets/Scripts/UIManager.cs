using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] GameObject InventoryUI;
    [SerializeField] Transform parentTransform;
    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        slots = parentTransform.GetComponentsInChildren<InventorySlot>(true);
        inventory.OnChangedCallback += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
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
        Debug.Log("UPDATING UI");

    }
}
