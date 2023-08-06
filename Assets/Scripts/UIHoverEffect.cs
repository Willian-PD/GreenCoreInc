using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public GameObject Panel;
    private TextMeshProUGUI targetText;

    public void Start()
    {
        targetText = Panel.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetText();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void GetText()
    {
        string description = GetComponentInChildren<Text>().text;
        targetText.text = description;
    }
}
