using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePassport : MonoBehaviour
{
    public GameObject uiElement;
    public GameObject passportButton;

    public void ActivateUI()
    {
        uiElement.SetActive(true);
        passportButton.SetActive(false);
    }

    public void DeactivateUI()
    {
        uiElement.SetActive(false);
    }

    public void ToggleUI()
    {
        uiElement.SetActive(!uiElement.activeSelf);
    }
}
