using UnityEngine;

public class TeammateMove : MonoBehaviour
{
    [Header("Settings")]
    public Transform player;      
    public float speed = 2f;       

    private EnemyAttack attack;    
    private SpriteRenderer sr;     

    void Start()
    {
        attack = GetComponent<EnemyAttack>();
        sr = GetComponent<SpriteRenderer>();

        if (!player)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
                player = p.transform;
        }
    }

    void Update()
    {
        if ((attack != null && attack.isAttacking) || player == null)
            return;

        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        Vector2 currentPos = transform.position;
        Vector2 direction = ((Vector2)player.position - currentPos).normalized;

        transform.position = currentPos + direction * speed * Time.deltaTime;
        
        if (direction.x > 0.05f)
            sr.flipX = false;
        else if (direction.x < -0.05f)
            sr.flipX = true;
    }
}
