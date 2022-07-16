using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Interactable/Weapon")]
public class Weapon : Equipment
{
    public float attackRange;
     
    public override void Use()
    {
        base.Use();
        
    }    
}
