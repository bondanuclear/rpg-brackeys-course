using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Mover : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target = null;
    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
    }
    private void Update() {
        if(target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        //Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 4f);
    }

    // Update is called once per frame
    public void Move(Vector3 point)
    {
        agent.SetDestination(point);
    }
    public void FollowTarget(Interactable focus)
    {
        target = focus.transform;
        agent.updateRotation = false;
        agent.stoppingDistance = focus.Radius * .8f;
    }
    public void StopFollowing()
    {
        target = null;
        agent.updateRotation = true;
        agent.stoppingDistance = 0f;
    }
}
