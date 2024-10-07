using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PASSPORTCloseableObject : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] GameObject passport;
    private AudioSource _audio;

    void Start() {
        if(gameObject.GetComponent<AudioSource>() != null)
        {
            _audio = GetComponent<AudioSource>();
            //_audio.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(_audio != null){
            _audio.Play();
        }
        passport.SetActive(true);
        
        Invoke("DeactivateGameObject", 0.25f); 
    }
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
