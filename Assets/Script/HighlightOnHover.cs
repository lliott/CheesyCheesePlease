using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HighlightUIOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image uiImage;
    private Color originalColor;
    public Color highlightColor = Color.yellow;

    void Start()
    {
        uiImage = GetComponent<Image>();
        if (uiImage != null)
        {
            originalColor = uiImage.color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (uiImage != null)
        {
            uiImage.color = highlightColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (uiImage != null)
        {
            uiImage.color = originalColor;
        }
    }
}
