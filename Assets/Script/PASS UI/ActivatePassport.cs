using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivatePassport : MonoBehaviour
{
    public GameObject uiElement;
    public GameObject passportButton;
    private AudioSource _audio;


    void Start(){
        _audio = GetComponent<AudioSource>();
    }


    public void ActivateUI()
    {
        uiElement.SetActive(true);
        passportButton.SetActive(false);
        _audio.Play();
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



