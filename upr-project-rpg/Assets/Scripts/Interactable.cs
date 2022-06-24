using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Transform placeToStop;
    [SerializeField] float radius;
    public float Radius {get {return radius;}}
    Transform player;
    bool isFocused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        if(placeToStop != null)
        Gizmos.DrawWireSphere(placeToStop.position, radius);
        else if (placeToStop == null)
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
