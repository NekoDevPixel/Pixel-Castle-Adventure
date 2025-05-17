using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextOnlyButton : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Color normalColor = Color.white;
    public Color pressedColor = Color.gray;

    public void OnPointerDown(PointerEventData eventData)
    {
        text.color = pressedColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        text.color = normalColor;
        // 원하는 클릭 이벤트 추가
        Debug.Log("Button Clicked!");
    }
}
