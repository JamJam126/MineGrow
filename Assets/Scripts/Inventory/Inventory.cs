using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    
    // (CROPS: AMOUNT)
    // EXAMPLE: (SPEII: 4)
    public InventorySlotData[] slots;
    public Item carrot;
    public Item wheat;
    public Item corn;

    private Dictionary<CropType, int> crops = new Dictionary<CropType, int>(); 
    public event Action OnInventoryChanged;
    // [SerializeField] private int InventorySize = 8;

    void Start()
    {
        // MOCK DATA
        // WILL REPLACE WITH AddCrop functions
        // crops.Add(CropType.Wheat, 5);
        // crops.Add(CropType.Carrot, 5);
        // crops.Add(CropType.Corn, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current Carrot: " + slots[0].amount); 
    }

    void Awake()
    {
        slots = new InventorySlotData[9];
        for (int i = 0; i < slots.Length; i++)
            slots[i] = new InventorySlotData();

        slots[0].item = carrot; slots[0].amount = 5;
        slots[1].item = wheat; slots[1].amount = 3;
        slots[2].item = corn;  slots[2].amount = 7;
    }
    

    // ADD CROP
    public void AddCrop(CropType type, int amount)
    {
        if (!crops.ContainsKey(type))
            crops[type] = 0;

        crops[type] += amount;
        OnInventoryChanged?.Invoke();
    }

    public bool AddItem(Item item, int amount)
    {
        if (item == null || amount <= 0) return false;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == item && item.stackable)
            {
                slots[i].amount += amount;
                OnInventoryChanged?.Invoke(); 
                return true;
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].item = item;
                slots[i].amount = amount;
                OnInventoryChanged?.Invoke(); 
                return true;
            }
        }

        Debug.LogWarning("Inventory is full! Could not add " + item.itemName);
        return false;
    }

    // REMOVE CROPS
    public bool RemoveCrop(CropType type, int amount)
    {
        if (!crops.ContainsKey(type) || crops[type] < amount)
            return false; // cannot remove

        crops[type] -= amount;

        if (crops[type] <= 0)
            crops.Remove(type);

        OnInventoryChanged?.Invoke();

        return true; 
    }

    public Dictionary<CropType, int> GetAllCrops()
    {
        return new Dictionary<CropType, int>(crops);
    }
}
