using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PASSPORTCloseableObject : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] GameObject passport;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        passport.SetActive(true);
    }
}
