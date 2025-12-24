[System.Serializable]
public class InventorySlotData
{
    public Item item;
    public int amount;

    public void Clear()
    {
        item = null;
        amount = 0;
    }
}