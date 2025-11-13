using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Coin Texts")]
    public TextMeshProUGUI coinText;      
    public TextMeshProUGUI coinText_GW;    
    public TextMeshProUGUI coinText_GO;    

    private int coin = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoinTexts(); 
    }

    public void AddCoin(int value)
    {
        coin += value;
        UpdateCoinTexts();
    }

    private void UpdateCoinTexts()
    {
        string coinString = coin.ToString();

        if (coinText != null)
            coinText.text = coinString;
        else
            Debug.LogWarning("coinText chưa được gán!");

        if (coinText_GW != null)
            coinText_GW.text = coinString;
        else
            Debug.LogWarning("coinText_GW chưa được gán!");

        if (coinText_GO != null)
            coinText_GO.text = coinString;
        else
            Debug.LogWarning("coinText_GO chưa được gán!");

        Debug.Log("Coin hiện tại: " + coin);
    }

    public int GetCoin()
    {
        return coin;
    }
}
