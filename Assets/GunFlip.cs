using UnityEngine;

public class GunFlip : MonoBehaviour
{
    public Transform player;  // Gán Player vào đây trong Inspector

    void Update()
    {
        // Nếu player đang quay trái (scale x < 0)
        if (player.localScale.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);  // Súng cũng quay trái
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);   // Súng quay phải
        }

        // Giữ thân súng nằm ngang (không cho xoay lung tung)
        transform.rotation = Quaternion.identity;
    }
}
