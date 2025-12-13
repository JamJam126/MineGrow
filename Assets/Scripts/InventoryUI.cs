using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform contentParent;
    public GameObject itemTextPrefab;

    private Dictionary<CropType, GameObject> uiItems = new Dictionary<CropType, GameObject>();

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach (var pair in inventory.GetAllCrops())
        {
            if (!uiItems.ContainsKey(pair.Key))
            {
                GameObject go = Instantiate(itemTextPrefab, contentParent);
                uiItems[pair.Key] = go;
            }

            uiItems[pair.Key]
                .GetComponent<TextMeshProUGUI>()
                .text = $"{pair.Key} x {pair.Value}";
        }
    }

    void OnEnable()
    {
        inventory.OnInventoryChanged += Refresh;
    }

    void OnDisable()
    {
        inventory.OnInventoryChanged -= Refresh;
    }
}
