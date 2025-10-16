using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform weaponHolder;  // Empty object ở tay Player
    public GameObject startingGun;  // Gán Prefab Súng vô đây

    private GameObject currentWeapon;
    private SpriteRenderer playerSprite;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        EquipWeapon(startingGun);
    }

    public void EquipWeapon(GameObject weaponPrefab)
    {
        if(currentWeapon != null) Destroy(currentWeapon);

        currentWeapon = Instantiate(weaponPrefab, weaponHolder.position, Quaternion.identity, weaponHolder);
    }

    void Update()
    {
        if (currentWeapon != null)
        {
            // Flip theo hướng Player
            var weaponSprite = currentWeapon.GetComponent<SpriteRenderer>();
            if (weaponSprite != null) weaponSprite.flipX = playerSprite.flipX;

            // Xoay theo chuột
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePos - currentWeapon.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            currentWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
