using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    [Header("UI hiển thị coin")]
    public TextMeshProUGUI coinText;

    private int totalCoin = 30; 

    private void Awake()
    {
        PlayerPrefs.DeleteAll();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        totalCoin = PlayerPrefs.GetInt("TotalCoin", totalCoin);
        UpdateCoinUI();
    }

    public bool SpendCoin(int cost)
    {
        if (totalCoin >= cost)
        {
            totalCoin -= cost;
            UpdateCoinUI();
            PlayerPrefs.SetInt("TotalCoin", totalCoin);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }

    public void AddCoin(int value)
    {
        totalCoin += value;
        UpdateCoinUI();
        PlayerPrefs.SetInt("TotalCoin", totalCoin);
        PlayerPrefs.Save();
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = totalCoin.ToString();
    }

    public int GetCoin() => totalCoin;
}
