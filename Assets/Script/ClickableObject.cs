using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject objectToDisplay;

    void Awake()
    {
        objectToDisplay.SetActive(false); 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!objectToDisplay.activeSelf)
        {
            objectToDisplay.SetActive(true);
        }
    }
}
