using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
   public Transform placeToStop;
    [SerializeField] float radius;
    public float Radius {get {return radius;}}
    Transform player;
    bool isFocused = false;
    bool hasInteracted = false;
    // Start is called before the first frame update
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }
    private void Start() {
        if (placeToStop == null) placeToStop = transform;
    }
    private void Update()
    {
        
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, placeToStop.position);
            if (distance < radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        hasInteracted = false;
        isFocused = true;
        player = playerTransform;
    }
    public void OnDefocused()
    {
        hasInteracted = false;
        isFocused = false;
        player = null;
    }
    // Update is called once per frame
   
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
