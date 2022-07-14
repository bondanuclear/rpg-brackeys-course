using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;
    public Stat armor;
    //public int maxHealth = 100;
    [SerializeField] private float currentHealth;

    private void Start() {
        currentHealth = GetComponent<BaseStats>().GetStat(StatEnum.Health);
    }
    private void Update() {
        // if(Input.GetKeyDown(KeyCode.T))
        // {
        //     TakeDamage(10);
        // }
    }
    public void TakeDamage(int damage)
    {
        damage -= armor.GetStat();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);


        currentHealth -= damage;
        
        Debug.Log("Player is taking " + damage + " damage.");    
        if(currentHealth <= 0)
        {
            
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log($"{transform.name} died.");
    }
}
