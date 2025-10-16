using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class ChestBehavior : MonoBehaviour
{
    public string playerTag = "Player";   // Tag player
    public float delayBeforeDestroy = 0.3f; // đợi 0.3s sau khi mở rồi biến mất
    public GameObject lootPrefab;         // (tùy chọn) item rơi ra
    public Transform lootSpawnPoint;      // (tùy chọn) vị trí spawn item

    private Animator anim;
    private bool opened = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        // tắt animator để rương không tự chuyển động ban đầu
        anim.enabled = false;

        // đảm bảo collider là trigger
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (opened) return;
        if (!other.CompareTag(playerTag)) return;

        opened = true;
        anim.enabled = true;            // bật animator
        anim.SetTrigger("Open");        // kích hoạt animation mở

        // chạy coroutine để chờ anim xong rồi biến mất
        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        // lấy thời lượng của animation "OpenBox"
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        float animLength = info.length;

        // chờ anim chạy + delay thêm chút
        yield return new WaitForSeconds(animLength + delayBeforeDestroy);

        // spawn loot (nếu có)
        if (lootPrefab != null)
        {
            Vector3 spawnPos = lootSpawnPoint ? lootSpawnPoint.position : transform.position;
            Instantiate(lootPrefab, spawnPos, Quaternion.identity);
        }

        // xóa rương
        Destroy(gameObject);
    }
}
