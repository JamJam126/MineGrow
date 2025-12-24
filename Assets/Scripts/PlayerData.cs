using System;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public Inventory Inventory { get; private set; }
    public TextMeshProUGUI goldText;
    public int balance { get; private set; } = 0;
    public event Action OnMoneyChanged;

    void Start()
    {
        UpdateGoldUI();
    }

    void Update()
    {

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
        UpdateGoldUI();
        OnMoneyChanged?.Invoke();
    }

    void UpdateGoldUI()
    {
        goldText.text = balance.ToString();
    }
}
