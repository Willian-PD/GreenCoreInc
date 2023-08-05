using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverEffect : MonoBehaviour
{
    private bool mouse_over;
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Debug.Log("Mouse exit");

    }
}
