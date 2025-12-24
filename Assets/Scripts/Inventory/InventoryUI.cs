using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public InventorySlotUI[] uiSlots;

    void Start()
    {
        Refresh();
    }

    void Refresh()
    {
        for (int i = 0; i < uiSlots.Length; i++)
            uiSlots[i].Set(inventory.slots[i]);
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
