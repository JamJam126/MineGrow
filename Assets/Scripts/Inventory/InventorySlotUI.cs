using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text amountText;

    public void Set(InventorySlotData data)
    {
        if (data.item == null)
        {
            icon.enabled = false;
            amountText.enabled = false;
            return;
        }

        icon.enabled = true;
        icon.sprite = data.item.icon;

        if (data.item.stackable && data.amount > 1)
        {
            amountText.enabled = true;
            amountText.text = data.amount.ToString();
        }
        else
        {
            amountText.enabled = false;
        }
    }
}
