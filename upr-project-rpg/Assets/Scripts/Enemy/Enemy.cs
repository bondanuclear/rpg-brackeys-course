using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    
    protected override void Start()
    {
        base.Start();
        GameObject player = PlayerManager.instance.player;
    }
    public override void Interact()
    {
        base.Interact();
        // attack the enemy
        //GameObject player = PlayerManager.instance.player;
        player.GetComponent<Fighter>().Attack(transform);
    }
    private void Update()
    {

        if (isFocused)
        {
            float distance = Vector3.Distance(player.position, placeToStop.position);
            if (distance < Radius)
            {
                //player.GetComponent<Mover>().StopFollowing();
                //Debug.Log(player.GetComponent<Fighter>().RangeOfAttack);
                Interact();
                
            }
        }
    }
    
}
