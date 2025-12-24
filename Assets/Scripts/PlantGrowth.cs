using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    [Header("Plant Settings")]
    public Inventory Inventory;
    public Sprite emptySprite;
    public Sprite[] growthStages;
    public float timePerStage = 2f;

    [Header("UI")]
    public GameObject seedPanel; 
    public GameObject backgroundPanel; 

    private SpriteRenderer sr;
    private int currentStage = 0;
    private float timer = 0f;

    private bool isPlanted = false;
    private bool isCollectible = false;

    // Static reference to the plant currently selected
    public static PlantGrowth selectedPlant;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = emptySprite;

        // hide UI at start
        if (seedPanel != null) seedPanel.SetActive(false);
        if (backgroundPanel != null) backgroundPanel.SetActive(false);
    }

    void Update()
    {
        if (isPlanted && !isCollectible)
        {
            timer += Time.deltaTime;

            if (timer >= timePerStage)
            {
                timer = 0f;
                currentStage++;

                if (currentStage < growthStages.Length)
                {
                    sr.sprite = growthStages[currentStage];
                }
                else
                {
                    isCollectible = true;
                    currentStage = growthStages.Length - 1;
                    Debug.Log("Plant ready to collect!");
                }
            }
        }
    }

    void OnMouseUpAsButton()
    {
        // block plant clicks if UI is open
        if (seedPanel != null && seedPanel.activeSelf)
            return;

        if (!isPlanted)
        {
            selectedPlant = this;
            seedPanel.SetActive(true);
            backgroundPanel.SetActive(true);
            return;
        }

        if (isCollectible)
        {
            ResetPlant();
        }
    }


    // Called by the seed button in the modal
    public void OnSeedButtonClicked()
    {
        if (selectedPlant != null)
        {
            selectedPlant.PlantSeed();   // plant seed on the clicked plant
            selectedPlant = null;        // reset selection
        }

        // Close modal
        CloseSeedPanel();
    }

    // Called by background panel click (optional)
    public void CloseSeedPanel()
    {
        if (seedPanel != null) seedPanel.SetActive(false);
        if (backgroundPanel != null) backgroundPanel.SetActive(false);
    }

    public void PlantSeed()
    {
        if (!isPlanted)
        {
            isPlanted = true;
            timer = 0f;
            currentStage = 0;
            sr.sprite = growthStages[0];
        }
    }

    void ResetPlant()
    {
        Inventory.AddCrop(CropType.Carrot, 3);
        isPlanted = false;
        isCollectible = false;
        timer = 0f;
        currentStage = 0;
        sr.sprite = emptySprite;
    }
}
