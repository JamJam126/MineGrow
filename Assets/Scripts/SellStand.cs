using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellStand : MonoBehaviour
{
    private bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Ke");
            OpenSellUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ke mk hz");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void OpenSellUI()
    {
        SellCrop(CropType.Wheat, 1);
    }

    public void SellCrop(CropType type, int amount)
    {   
        Inventory inventory = PlayerData.Instance.Inventory;

        if (!inventory.RemoveCrop(type, amount))
            return;

        int price = GetPrice(type);
        PlayerData.Instance.AddMoney(price * amount);
    }

    private int GetPrice(CropType type)
    {
        return 10;
    }
}
