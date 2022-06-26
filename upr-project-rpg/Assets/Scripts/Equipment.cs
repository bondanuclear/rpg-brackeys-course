using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Interactable/Equipment")]
public class Equipment : Item
{
    public int attackModifier;
    public int defenseModifier;
    public EquipmentSlot equipmentSlot;
    public override void Use()
    {
        base.Use();
        // Put equipment on
        EquipmentManager.instance.Equip(this);
        // Delete it from inventory
        RemoveItem();    
    }
}    
public enum EquipmentSlot{
    Head, Chest, Legs, Weapon, Shield, Boots
}    

