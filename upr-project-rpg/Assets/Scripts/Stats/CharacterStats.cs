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
    public float CurrentHealth {get {return currentHealth;}}
    private void Start() {
        currentHealth = GetComponent<BaseStats>().GetStat(StatEnum.Health);
    }
    private void Update() {
        // if(Input.GetKeyDown(KeyCode.T))
        // {
        //     TakeDamage(10);
        // }
    }
    public void TakeDamage(int damage, GameObject instigator)
    {
        damage -= armor.GetStat();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);


        currentHealth -= damage;
        
        Debug.Log("Player is taking " + damage + " damage.");    
        if(currentHealth <= 0)
        {
            Debug.Log("IM INSTIGATOR!! " + instigator.name);
            StartCoroutine(ProcessDeath(instigator));
            // ExperienceReward(instigator);
            // Die();
        }
    }

    private void ExperienceReward(GameObject instigator)
    {
        Experience experience = instigator.GetComponent<Experience>();
        if(experience == null) return;
        else if (experience != null)
        {
            experience.GainExperience(GetComponent<BaseStats>().GetStat(StatEnum.ExperienceReward));
        }
    }

    public virtual void Die()
    {

        Debug.Log($"{transform.name} died.");
    }
    IEnumerator ProcessDeath(GameObject instigator)
    {
        ExperienceReward(instigator);
        yield return null;
        Die();
    }
}
