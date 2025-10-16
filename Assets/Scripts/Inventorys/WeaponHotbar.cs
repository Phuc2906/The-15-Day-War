using UnityEngine;
using UnityEngine.UI;
using System;

public class WeaponHotbar : MonoBehaviour
{
    [Header("UI icon cho 3 ô")]
    public Image[] slots = new Image[3];

    [Header("Vũ khí trong 3 slot")]
    public WeaponSlotData[] weapons = new WeaponSlotData[3];

    public int activeIndex = 0;

    // Event cho controller nghe khi đổi slot
    public event Action<WeaponSlotData> OnSelectionChanged;

    void Start() => RefreshUI();

    void Update()
    {
        // phím 1–3
        for (int i = 0; i < 3; i++)
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                SelectSlot(i);

        // lăn chuột
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            int dir = (int)Mathf.Sign(scroll);
            SelectSlot((activeIndex - dir + 3) % 3);
        }
    }

    public void SelectSlot(int idx)
    {
        idx = Mathf.Clamp(idx, 0, weapons.Length - 1);
        if (idx == activeIndex) return;

        activeIndex = idx;
        RefreshUI();
        OnSelectionChanged?.Invoke(GetCurrentSlot());
    }

    void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i]) continue;
            var data = (i < weapons.Length) ? weapons[i] : null;

            // ✅ Chỉ đổi sprite nếu có weapon
            if (data != null && data.prefab != null)
            {
                slots[i].sprite = data.icon;
                slots[i].enabled = true;
            }
            // ❌ Nếu chưa có weapon thì giữ nguyên hình trong Editor

            // Làm mờ slot không active
            slots[i].color = (i == activeIndex) ? Color.white : new Color(1, 1, 1, 0.5f);
        }
    }

    // thêm vũ khí vào hotbar
    public bool AddWeapon(Sprite icon, GameObject prefab)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] == null || weapons[i].prefab == null)
            {
                weapons[i] = new WeaponSlotData { icon = icon, prefab = prefab };
                RefreshUI();
                return true;
            }
        }
        Debug.Log("Hotbar đầy!");
        return false;
    }

    public WeaponSlotData GetCurrentSlot()
    {
        return (activeIndex < weapons.Length) ? weapons[activeIndex] : null;
    }
}
