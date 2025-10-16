using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WeaponPickup : MonoBehaviour
{
    public Sprite weaponIcon;          // icon hiện ở hotbar
    public GameObject weaponPrefab;    // prefab súng để cầm

    private void Reset()
    {
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var refHotbar = other.GetComponent<PlayerHotbarRef>();
        if (refHotbar != null && refHotbar.hotbar != null)
        {
            // ✅ truyền đủ 2 tham số: icon + prefab
            if (refHotbar.hotbar.AddWeapon(weaponIcon, weaponPrefab))
            {
                Destroy(gameObject);
            }
        }
    }
}
