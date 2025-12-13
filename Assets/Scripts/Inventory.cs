using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    
    // (CROPS: AMOUNT)
    // EXAMPLE: (SPEII: 4)
    private Dictionary<CropType, int> crops = new Dictionary<CropType, int>(); 
    public event Action OnInventoryChanged;

    void Start()
    {
        // MOCK DATA
        // WILL REPLACE WITH AddCrop functions
        crops.Add(CropType.Wheat, 5);
        crops.Add(CropType.Carrot, 5);
        crops.Add(CropType.Corn, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ADD CROP
    public void AddCrop(CropType type, int amount)
    {
        if (!crops.ContainsKey(type))
            crops[type] = 0;

        crops[type] += amount;
        OnInventoryChanged?.Invoke();
    }

    // REMOVE CROPS
    public Dictionary<CropType, int> GetAllCrops()
    {
        return new Dictionary<CropType, int>(crops);
    }
}
