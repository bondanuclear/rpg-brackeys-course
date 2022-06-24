using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Mover))]
public class PlayerController : MonoBehaviour
{
    Camera playerCamera;
    Mover mover;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // start moving with left mouse button
                mover.Move(hit.point);
                // TO DO stop other interactions

            }
        }
    }
}
