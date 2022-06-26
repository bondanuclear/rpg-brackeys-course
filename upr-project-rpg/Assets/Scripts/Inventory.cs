using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    [SerializeField] int inventoryCapacity = 3;
    public static Inventory instance;
    public delegate void OnInventoryChanged();
    public OnInventoryChanged OnChangedCallback;
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
        if(!item.isDefaultItem)
        {
            itemList.Add(item);
            if(OnChangedCallback != null)
                OnChangedCallback.Invoke();
        }
            
            
        
    }
    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
        if (OnChangedCallback != null)
            OnChangedCallback.Invoke();
    }
}
