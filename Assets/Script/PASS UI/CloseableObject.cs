using UnityEngine;
using UnityEngine.EventSystems;

public class CloseableObject : MonoBehaviour, IPointerClickHandler
{
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
        Invoke("DeactivateGameObject", 0.25f); 
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}