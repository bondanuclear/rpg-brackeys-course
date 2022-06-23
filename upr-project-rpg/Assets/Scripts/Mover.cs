using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Mover : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;
           if(Physics.Raycast(ray, out hit))
           {
                agent.destination = hit.point;
           }
        }
    }
}
