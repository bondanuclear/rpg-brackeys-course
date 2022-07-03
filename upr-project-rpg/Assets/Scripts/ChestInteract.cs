using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : Interactable
{
    
    public override void Interact()
    {
        base.Interact();
        ChestManager chestManager = GetComponent<ChestManager>();
        chestManager.SetUsed(true);
        //UIManager uiManager = FindObjectOfType<UIManager>();
       // uiManager.ProcessUI(true);
       // uiManager.ProcessChestUI(true);   
        
    }
    
        
}
