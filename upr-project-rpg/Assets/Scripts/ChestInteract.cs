using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : Interactable
{
    public override void Interact()
    {
        base.Interact();
        FindObjectOfType<UIManager>().OpenUI();
    }
}
