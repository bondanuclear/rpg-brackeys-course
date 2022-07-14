using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterClass))]
public class Fighter : MonoBehaviour
{
    [SerializeField] float timeBetweenHits = 1.2f;
    float coolDown;
    CharacterStats characterStats;
    Transform target = null;
    BaseStats baseStats;
    // Start is called before the first frame update
    void Start()
    {
        baseStats = GetComponent<BaseStats>();
        characterStats = GetComponent<CharacterStats>();
    }
    public void Attack(Transform objectToAttack)
    {
        Hit(objectToAttack);
    }
    public void Hit(Transform objectToAttack)
    {
        target = objectToAttack;
        if(target == null) return;
        CharacterStats characterStatsTarget = target.GetComponent<CharacterStats>();
        
        if(coolDown >= timeBetweenHits)
        {
            coolDown = 0;
            int damage = characterStats.damage.GetStat() + (int)baseStats.GetStat(StatEnum.Damage);
            characterStatsTarget.TakeDamage(damage);
            //Debug.Log($"{characterStatsTarget.name} took" + damage + " damage");
        }
    }
    // Update is called once per frame
    void Update()
    {
        coolDown += Time.deltaTime;
    }
}
