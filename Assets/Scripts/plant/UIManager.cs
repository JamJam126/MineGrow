using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Panels")]
    public GameObject seedPanel;
    public GameObject backgroundPanel;

    private PlantGrowth currentPlant;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ClosePanels();
    }

    public void OpenSeedPanel(PlantGrowth plant)
    {
        currentPlant = plant;
        seedPanel.SetActive(true);
        backgroundPanel.SetActive(true);
    }

    public void ClosePanels()
    {
        seedPanel.SetActive(false);
        backgroundPanel.SetActive(false);
        currentPlant = null;
    }

    public void OnSeedButtonClicked()
    {
        bool hasCarrotSeeds = PlayerData.Instance.Inventory.HasItem(
            PlayerData.Instance.Inventory.carrotSeed
        );
        
        if (currentPlant != null && hasCarrotSeeds)
        {
            currentPlant.PlantSeed();
        }

        else Debug.Log("You don't have enough carrot seed!");

        ClosePanels();
    }
}
