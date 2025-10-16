using UnityEngine;
using TMPro;

public class EnemyCountDisplay : MonoBehaviour
{
    public TMP_Text enemyCountText;

    // ✅ Không dùng biến đếm nội bộ nữa

    void Start()
    {
        if (enemyCountText != null)
            enemyCountText.text = "0/100";  // hoặc để trống ban đầu
    }

    public void UpdateCount(int killed, int total)
    {
        if (enemyCountText != null)
            enemyCountText.text = killed + "/" + total;
    }
}
