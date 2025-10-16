using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    public float detectionRange = 8f;
    public LayerMask enemyLayer; // Layer của Enemy

    private float fireTimer = 0f;
    private SpriteRenderer playerSprite;

    void Start()
    {
        playerSprite = GetComponentInParent<SpriteRenderer>();
        fireTimer = 0f;
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;

        FlipWithPlayer();          // Xoay súng theo Player
        StickGunHorizontally();    // Giữ súng nằm ngang

        Transform nearestEnemy = FindNearestEnemy(); // Tìm enemy gần nhất

        if (nearestEnemy != null)
        {
            AimAtEnemy(nearestEnemy.position);  // Chĩa FirePoint về phía enemy

            if (fireTimer <= 0f)
            {
                Shoot();
                fireTimer = fireRate;
            }
        }
    }

    void FlipWithPlayer()
    {
        if (playerSprite != null)
        {
            Vector3 scale = transform.localScale;
            scale.x = playerSprite.flipX ? -1 : 1;
            transform.localScale = scale;
        }
    }

    void StickGunHorizontally()
    {
        // Dù enemy ở trên hay dưới cũng không cho súng xoay lên/xuống
        Vector3 euler = transform.localEulerAngles;
        euler.z = 0;
        transform.localEulerAngles = euler;
    }

    Transform FindNearestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(firePoint.position, detectionRange, enemyLayer);
        Transform nearest = null;
        float minDist = detectionRange;

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float dist = Vector2.Distance(firePoint.position, hit.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    nearest = hit.transform;
                }
            }
        }
        return nearest;
    }

    void AimAtEnemy(Vector3 targetPos)
    {
        Vector2 direction = (targetPos - firePoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Xoay FirePoint để chĩa đúng hướng enemy, nhưng giữ thân súng ngang
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Shoot()
{
    if (bulletPrefab == null)
    {
        Debug.LogError("⚠️ bulletPrefab chưa được gán trong Inspector!");
        return;
    }

    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
#if UNITY_6000_0_OR_NEWER
        rb.linearVelocity = firePoint.right * bulletSpeed;
#else
        rb.velocity = firePoint.right * bulletSpeed;
#endif
    }
    else
    {
        Debug.LogWarning("⚠️ Bullet không có Rigidbody2D! Không thể bay được.");
    }
}


    void OnDrawGizmosSelected()
    {
        if (firePoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(firePoint.position, detectionRange);
        }
    }
}
