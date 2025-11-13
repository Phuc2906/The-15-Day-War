using UnityEngine;

public class GunFlip : MonoBehaviour
{
    public Transform player;  

    void Update()
    {
        if (player.localScale.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);  
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);  
        }

        transform.rotation = Quaternion.identity;
    }
}
