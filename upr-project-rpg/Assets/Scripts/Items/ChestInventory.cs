using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventory : MonoBehaviour
{
    #region Singleton
    public static ChestInventory instance;
    private void Awake() {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion
    public List<Item> chestItems = new List<Item>();
    [SerializeField] int chestCapacity = 30;
    public delegate void OnChestChanged();
    public OnChestChanged onChestChanged;
    void Start()
    {
        
    }
    public bool checkCapacity()
    {
        if(chestItems.Count < chestCapacity)
        {
            return true;
        } else return false;
    }
    public void AddToChest(Item item)
    {
        if(checkCapacity())
            chestItems.Add(item);
        if(onChestChanged != null)
        {
            onChestChanged.Invoke();
        }
    }
    public void RemoveFromChest(Item item)
    {
        chestItems.Remove(item);
        if (onChestChanged != null)
        {
            onChestChanged.Invoke();
        }
    }
    // Update is called once per frame
    
}
