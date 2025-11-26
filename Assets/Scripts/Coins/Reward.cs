using UnityEngine;

public class Reward : MonoBehaviour
{
    public int rewardValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoin(rewardValue);
            Destroy(gameObject);
        }
    }
}
