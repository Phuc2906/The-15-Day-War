using UnityEngine;
using UnityEngine.EventSystems;

public class SlotClickHandler : MonoBehaviour, IPointerClickHandler
{
    public WeaponHotbar hotbar; // kéo object chứa WeaponHotbar vào
    public int index;           // 0,1,2 tương ứng ô

    public void OnPointerClick(PointerEventData eventData)
    {
        if (hotbar != null) hotbar.SelectSlot(index);
    }
}
