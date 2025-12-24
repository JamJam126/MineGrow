using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public bool stackable = true;
    public int maxStack = 99;

    public int sellPrice;
}
