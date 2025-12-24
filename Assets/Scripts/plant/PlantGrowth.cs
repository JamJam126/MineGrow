using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    [Header("Plant Settings")]
    public Sprite emptySprite;
    public Sprite[] growthStages;
    public float timePerStage = 2f;

    private SpriteRenderer sr;
    private int currentStage = 0;
    private float timer = 0f;
    private bool isPlanted = false;
    private bool isCollectible = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = emptySprite;
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
                    sr.sprite = growthStages[currentStage];
                else
                {
                    isCollectible = true;
                    currentStage = growthStages.Length - 1;
                }
            }
        }
    }

    void OnMouseUpAsButton()
    {
        if (!isPlanted)
        {
            UIManager.Instance.OpenSeedPanel(this); // tell UIManager
        }
        else if (isCollectible)
        {
            ResetPlant();
        }
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
        isPlanted = false;
        isCollectible = false;
        timer = 0f;
        currentStage = 0;
        sr.sprite = emptySprite;
    }
}
