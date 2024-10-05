using UnityEngine;
using UnityEngine.EventSystems;

public class CloseableObject : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}