using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExpManager : MonoBehaviour
{
    public Slider expBar;           
    public TMP_Text levelText;         

    private int level = 1;
    private int currentExp = 0;
    private int expToNextLevel = 100;

    void Start()
    {
        expBar.maxValue = expToNextLevel;
        expBar.value = currentExp;
        levelText.text = "Level " + level;
    }

    public void GainExp(int amount)
    {
        currentExp += amount;

        // Nếu đạt hoặc vượt exp cần thiết
        if (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            level++;
            levelText.text = "Level " + level;
        }

        // ✅ Cập nhật thanh kinh nghiệm
        expBar.value = currentExp;
    }
}
