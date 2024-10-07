using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulebookUI : MonoBehaviour
{
    [SerializeField] private GameObject secondObjectToDisplay;
    [SerializeField] private GameObject firstObjectToDisplay;
    private AudioSource _audio;

    void Start(){
        _audio = GetComponent<AudioSource>();
    }

    public void OnClickEnableFirst()
    {
        _audio.Play();
        setActiveTrue();
        setActiveFalse1();
    }

    public void OnClickEnableSecond()
    {
        _audio.Play();
        setActiveFalse();
        setActiveTrue1();
    }

    public void setActiveTrue()
    {
        firstObjectToDisplay.SetActive(true);
    }
    public void setActiveFalse()
    {
        firstObjectToDisplay.SetActive(false);
    }
    public void setActiveTrue1()
    {
        secondObjectToDisplay.SetActive(true);
    }
    public void setActiveFalse1()
    {
        secondObjectToDisplay.SetActive(false);
    }
}
