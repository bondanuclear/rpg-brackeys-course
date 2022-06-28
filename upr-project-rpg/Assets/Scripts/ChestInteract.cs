using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : Interactable
{
    GameObject chestUI;
   
    public override void Interact()
    {
        base.Interact();
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ProcessUI(true);
        uiManager.ProcessChestUI(true);   
        
    }
    
        
}
