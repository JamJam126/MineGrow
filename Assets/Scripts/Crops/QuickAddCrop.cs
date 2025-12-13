using UnityEngine;


// AH FILE NIS TEST LG TE
public class QuickAddCrop : MonoBehaviour
{
    public Inventory inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            inventory.AddCrop(CropType.Wheat, 5);

        if (Input.GetKeyDown(KeyCode.X))
            inventory.AddCrop(CropType.Carrot, 5);

        if (Input.GetKeyDown(KeyCode.C))
            inventory.AddCrop(CropType.Corn, 5);
    }
}
