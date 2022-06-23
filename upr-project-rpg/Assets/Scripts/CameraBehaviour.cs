using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Mover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate() {
        transform.position = player.position + offset;
    }
}
