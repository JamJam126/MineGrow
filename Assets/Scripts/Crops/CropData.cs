using UnityEngine;


[CreateAssetMenu(menuName = "Farming/Crop Data")]
public class CropData : ScriptableObject
{
    // INFORMATION BOS CROP NI MUY MUY (NAME, GROWTIME, PRICE ....)
    public CropType type;
    public int sellPrice;

}