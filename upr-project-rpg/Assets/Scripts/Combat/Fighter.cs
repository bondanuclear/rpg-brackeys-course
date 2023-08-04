using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterClass))]
public class Fighter : MonoBehaviour
{
    [SerializeField] float timeBetweenHits = 1.2f;
    public float rangeOfAttack = 1.5f;
    [SerializeField] float delayOfAttack = 0.5f;
    [SerializeField] float combatCooldown = 4f;
    float timeSinceLastAttack;
    float coolDown;
    CharacterStats characterStats;
    Transform target = null;
    BaseStats baseStats;
    public event Action OnAttack;
    float statAttackPower;
    public bool inCombat {get; private set;}
    // private void OnEnable() {
    //     EquipmentManager.instance.onEquipmentChanged += AdjustRange;
    // }

    // private void AdjustRange(Equipment newItem, Equipment oldItem)
    // {
    //     if(gameObject.tag != "Player") return;
        
    //     if(newItem.equipmentSlot != EquipmentSlot.Weapon) return;
    //     Debug.Log(newItem.name + "NEW ITEM NAME");Debug.Log(newItem.name + "NEW ITEM NAME");
    //     if(newItem != null)
    //     {
    //          Weapon weapon = (Weapon)newItem;
    //          rangeOfAttack = weapon.attackRange;
    //     }
    // }

    // Start is called before the first frame update
    
    void Awake()
    {
        baseStats = GetComponent<BaseStats>();
        characterStats = GetComponent<CharacterStats>();
    }
    private void Start() {
        statAttackPower = baseStats.GetStat(StatEnum.Damage);
    }
    private void OnEnable() {
        baseStats.HasLeveledUp += UpdateAttackPower;
    }

    private void UpdateAttackPower()
    {
        statAttackPower = baseStats.GetStat(StatEnum.Damage);
    }

    public void Attack(Transform objectToAttack)
    {
        target = objectToAttack;
        if (target == null) return;
        CharacterStats characterStatsTarget = target.GetComponent<CharacterStats>();

        if (coolDown >= timeBetweenHits)
        {
            coolDown = 0;
            OnAttack?.Invoke();
            StartCoroutine(DoDamage(characterStatsTarget, delayOfAttack));
            inCombat = true;
            timeSinceLastAttack = Time.time;
            //Debug.Log($"{characterStatsTarget.name} took" + damage + " damage");
        }
    }

    private IEnumerator DoDamage(CharacterStats characterStatsTarget, float delayOfAttack)
    {
        yield return new WaitForSeconds(delayOfAttack);
        int damage = characterStats.damage.GetStat() + (int)statAttackPower;
        characterStatsTarget.TakeDamage(damage, gameObject);
        if(characterStatsTarget.CurrentHealth <= 0)
        {
            inCombat = false;
        }
    }

    
    void Update()
    {
        coolDown += Time.deltaTime;
        if(Time.time - timeSinceLastAttack > combatCooldown)
        {
            inCombat = false;
        }
    }
}
