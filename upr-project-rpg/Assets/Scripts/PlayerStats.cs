using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += UpdateModifiers;
    }

  
    public void UpdateModifiers(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            damage.AddModifier(newItem.attackModifier);
            armor.AddModifier(newItem.defenseModifier);
            
        }
        if(oldItem != null)
        {
            damage.RemoveModifier(oldItem.attackModifier);
            armor.RemoveModifier(oldItem.defenseModifier);
        }

    }

}
