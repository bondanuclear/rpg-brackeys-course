using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotEquipment : MonoBehaviour
{
    Equipment equipment;
    public Image icon;
    public void AddEquipmentSlot(Equipment newEquipment)
    {
        equipment = newEquipment;
        icon.sprite = equipment.sprite;
        icon.enabled = true;
        
    }
    public void RemoveEquipmentSlot()
    {
        if (equipment != null)
        {
            // Inventory.instance.AddItem(equipment);
            EquipmentManager.instance.Unequip(EquipmentManager.instance.GetEquipmentIndex(equipment));
        }
        equipment = null;
        icon.sprite = null;
        icon.enabled = false;
        
        
    }
}
