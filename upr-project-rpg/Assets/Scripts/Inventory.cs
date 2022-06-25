using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> itemList = new List<Item>();
    [SerializeField] int inventoryCapacity = 3;
    public static Inventory instance;
    private void Awake() {
        if(instance != null) return;
        else instance = this; 

    }
    public bool checkCapacity()
    {
        if(itemList.Count < inventoryCapacity)
        {
            return true;
        } else return false;
    }
    public void AddItem(Item item)
    {
        
            itemList.Add(item);
            
        
    }
    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }
}
