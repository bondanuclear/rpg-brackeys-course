using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
       public static EquipmentManager instance; 
        private void Awake() {
            if(instance != null)
            {
                Debug.LogWarning("Already have an instance of the equipment manager");
                return;
            }
            instance = this;
        }

    #endregion
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    [SerializeField] Equipment[] slots;
    int sizeOfSlots;
    private void Start() {
        sizeOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        slots = new Equipment[sizeOfSlots];
    }
    public void Equip(Equipment equipment)
    {
        int slotIndex = (int) equipment.equipmentSlot;
        Equipment oldEquipment = null;
        if(slots[slotIndex] != null)
        {
            oldEquipment = slots[slotIndex];
            Inventory.instance.AddItem(oldEquipment);    
        }
        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(equipment, oldEquipment);
        }
        slots[slotIndex] = equipment;
        
    }
    public void Unequip(int slotIndex)
    {
        if(slots[slotIndex] != null)
        {
            Inventory.instance.AddItem(slots[slotIndex]);
            slots[slotIndex] = null;
        }
        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(null, slots[slotIndex]);
        }
    }
    public void UnequipAll()
    {
        for(int i = 0; i < slots.Length; i++)
        {
           Unequip(i);
        }
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
