using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    Fighter fighter;
    [SerializeField] float radius = 8f;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        fighter = GetComponent<Fighter>();
    }
    private void Update() {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= radius)
        {
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance)
            {
                // attack the target
                FaceTarget();
                fighter.Attack(target);
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5*Time.deltaTime);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
