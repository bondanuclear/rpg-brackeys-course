using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterAnimator : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    Fighter fighter;
    // Start is called before the first frame update
    private void OnEnable() {
        GetComponent<Fighter>().OnAttack += Attack;
    }
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        fighter = GetComponent<Fighter>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedCoef = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedCoef", speedCoef, 0.125f, Time.deltaTime);
        animator.SetBool("inCombat", fighter.inCombat);
        
    }
    protected virtual void Attack()
    {
        animator.SetTrigger("attack");
    }
}
