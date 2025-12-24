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
            Debug.Log("Opening Sell UI");
            OpenSellUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in range");
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
        // Example: selling 1 carrot item
        Item carrotItem = Resources.Load<Item>("Items/Item_Carrot"); // make sure your Item asset is here
        SellCrop(carrotItem, 1);
    }

    public void SellCrop(Item item, int amount)
    {   
        Inventory inventory = PlayerData.Instance.Inventory;

        // if (!inventory.RemoveItem(item, amount))
        //     return;

        int price = GetPrice(item);
        PlayerData.Instance.AddMoney(price * amount);
    }

    private int GetPrice(Item item)
    {
        return item != null ? item.sellPrice : 0;
    }
}
