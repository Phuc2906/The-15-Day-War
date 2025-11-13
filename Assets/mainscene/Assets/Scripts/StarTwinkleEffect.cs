using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; // Quan trọng: Phải cài đặt DOTween từ Asset Store

public class StarTwinkleEffect : MonoBehaviour
{
    private Image starImage;

    // Tùy chỉnh trong Inspector
    public float minDuration = 0.5f; // Thời gian nháy nhanh nhất
    public float maxDuration = 1.5f; // Thời gian nháy chậm nhất
    public float minDelay = 0f;      // Độ trễ ban đầu tối thiểu
    public float maxDelay = 1f;      // Độ trễ ban đầu tối đa

    void Start()
    {
        starImage = GetComponent<Image>();
        Twinkle();
    }

    void Twinkle()
    {
        // 1. Độ sáng giảm (Fade out)
        float duration1 = Random.Range(minDuration, maxDuration);

        starImage.DOFade(0.3f, duration1) // Giảm Alpha xuống 0.3
            .SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                // 2. Độ sáng tăng (Fade in)
                float duration2 = Random.Range(minDuration, maxDuration);
                starImage.DOFade(1f, duration2) // Tăng Alpha lên 1f
                    .SetEase(Ease.InSine)
                    .OnComplete(() =>
                    {
                        // 3. Lặp lại với độ trễ ngẫu nhiên
                        float randomDelay = Random.Range(minDelay, maxDelay);
                        Invoke("Twinkle", randomDelay);
                    });
            });
    }
}