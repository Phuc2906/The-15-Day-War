using UnityEngine;

public class TeammateMove : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float stopDistance = 0.05f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.freezeRotation = true;

        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

            if (sr != null)
                sr.flipX = direction.x < 0;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}

