using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] float zoom = 40f;
    [SerializeField] float pitch = 2f;
    [SerializeField] float maxZoom = 20f;
    [SerializeField] float minZoom = 5f;
    Transform player;
    [SerializeField] private float rotationSpeed;
    private float rotationCoef = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Mover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
         rotationCoef -= Input.GetAxis("Horizontal") *  rotationSpeed * Time.deltaTime; 
    }

    private void Zoom()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * smoothSpeed;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
    }

    private void LateUpdate() {
        
        transform.position = player.position - offset * zoom;
        transform.LookAt(player.position + Vector3.up * pitch );
        transform.RotateAround(player.transform.position, Vector3.up, rotationCoef);

    }
}
