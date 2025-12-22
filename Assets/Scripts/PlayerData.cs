using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public Inventory Inventory { get; private set; }

    public int balance { get; private set; } = 0;
    public event Action OnMoneyChanged;

    void Update()
    {
        Debug.Log("Player Balance: " + balance); 
    }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Inventory = GetComponent<Inventory>();
    }

    public void AddMoney(int amount) {
        balance += amount;
        OnMoneyChanged?.Invoke();
    }
}
