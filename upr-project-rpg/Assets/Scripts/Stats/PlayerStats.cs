using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void OnEnable()
    {
        EquipmentManager.instance.onEquipmentChanged += UpdateModifiers;
        GetComponent<BaseStats>().HasLeveledUp += UpdateHealth;
    }
    private void OnDisable() {
        EquipmentManager.instance.onEquipmentChanged -= UpdateModifiers;
        GetComponent<BaseStats>().HasLeveledUp -= UpdateHealth;
    }
    private void UpdateHealth()
    {
        maxHealth = GetComponent<BaseStats>().GetStat(StatEnum.Health);
        CurrentHealth = maxHealth;
        Debug.Log($"Now maxHealth equals to {maxHealth}");
    }

    public void UpdateModifiers(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            damage.AddModifier(newItem.attackModifier);
            armor.AddModifier(newItem.defenseModifier);
            
        }
        // Debug.LogWarning("CALLING UPDATE MODIFIERS");
        // Debug.Log("NEW ITEM = " + newItem);
        // Debug.Log("OLD ITEM = " + oldItem);
        if(oldItem != null)
        {
            damage.RemoveModifier(oldItem.attackModifier);
            armor.RemoveModifier(oldItem.defenseModifier);
        }

    }
    public override void Die()
    {
        base.Die();
        
    }
}
