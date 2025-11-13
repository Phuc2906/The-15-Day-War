using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    private SpriteRenderer sr; 

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }
    }

    void Update()
    {
        if (!player) return;

        Vector2 pos = transform.position;
        Vector2 dir = ((Vector2)player.position - pos).normalized;

        transform.position = pos + dir * speed * Time.deltaTime;

        if (dir.x > 0.05f)
            sr.flipX = false;
        else if (dir.x < -0.05f)
            sr.flipX = true;
    }
}
