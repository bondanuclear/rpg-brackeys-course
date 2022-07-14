using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item", menuName = "Interactable/Item")]
public class Item : ScriptableObject
{
    new public string name;
    public Sprite sprite;
    public bool isDefaultItem;
    public virtual void Use()
    {
        Debug.Log($"Using item {name} " );
    }
    public void RemoveItem()
    {
        Inventory.instance.RemoveItem(this);
    }
}
