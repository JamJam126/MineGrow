using UnityEngine;

[CreateAssetMenu(
    fileName = "NewBuildingData",
    menuName = "Building/Building Data"
)]
public class BuildingData : ScriptableObject
{
    public string buildingName;
    public GameObject prefab;
    public int price;
}
