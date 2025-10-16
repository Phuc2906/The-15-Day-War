using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;
    public EnemySpawner spawner;

    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("Dead");

        if (spawner != null)
            spawner.OnEnemyKilled();

        Collider2D col = GetComponent<Collider2D>();
        if (col) col.enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (var s in scripts)
        {
            if (s != this) s.enabled = false;
        }

        Destroy(gameObject, 1f);
    }
}
