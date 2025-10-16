using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Tấn công")]
    public int damage = 5;             // Sát thương mỗi lần chạm
    public float attackCooldown = 0.5f; // Khoảng thời gian giữa 2 đòn

    private float lastHitTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var hp = other.GetComponent<PlayerHealth>();
        if (hp == null) return;

        hp.TakeDamage(damage);
        lastHitTime = Time.time;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (Time.time - lastHitTime < attackCooldown) return;

        var hp = other.GetComponent<PlayerHealth>();
        if (hp == null) return;

        hp.TakeDamage(damage);
        lastHitTime = Time.time;
    }
}
