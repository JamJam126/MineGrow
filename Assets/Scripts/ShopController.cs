using UnityEngine;

public class ShopController : MonoBehaviour
{
    void Start()
    {
        // Make sure shop is hidden when the game starts
        gameObject.SetActive(false);
    }

    public void OpenShop()
    {
        gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
