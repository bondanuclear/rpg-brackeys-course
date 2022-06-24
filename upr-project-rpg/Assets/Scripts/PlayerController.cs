using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Mover))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Interactable focus;
    [SerializeField] LayerMask layerMask;
    Camera playerCamera;
    Mover mover;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        playerCamera = Camera.main;
    }
    private void FixedUpdate() {
        // if(focus != null)
        // {
        //     float distance = Vector3.Distance(transform.position, focus.transform.position);
        //     if( distance < focus.Radius)
        //     {
        //         Vector3 direction = (focus.transform.position - transform.position).normalized;
        //         Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        //         transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 4f);
        //     }
        // }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, layerMask))
            {
                Unfocus();
                // start moving with left mouse button
                mover.Move(hit.point);
                // TO DO stop other interactions

            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Interactable interactable = hit.transform.GetComponent<Interactable>();
               if(interactable != null)
               {
                    Debug.Log("Hit an interactable + " + hit.transform.name + " object! ");
                    SetFocus(interactable);
               }

            }
        }
    }
    public void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        mover.FollowTarget(focus);
    }
    public void Unfocus()
    {
        focus = null;
        mover.StopFollowing();
    }
}
