using UnityEngine;

public class ShopBuildingButton : MonoBehaviour
{
    public BuildingData building;

    public void StartPlacement()
    {
        BuildManager.Instance.StartPlacement(building);
    }
}
