using UnityEngine;
using UnityEngine.EventSystems;


public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Temperature _tempScript;
    [SerializeField] private GameObject objectToDisplay;
    [SerializeField] private float _displayTime;
    private float _remainingTime ;
    private bool _isDisplaying = false;
    private AudioSource _audio;


    void Awake()
    {
        objectToDisplay.SetActive(false);
        ResetDialogue() ;
       
    }  


    void Start() {
        if(gameObject.GetComponent<AudioSource>() != null)
        {
            _audio = GetComponent<AudioSource>();
            //_audio.enabled = false;
        }
    }


    void Update(){
        if(_displayTime != 0){
            if(_remainingTime>0  && _isDisplaying){
                _remainingTime -= Time.deltaTime;
            }else{
                _isDisplaying = false ;
                objectToDisplay.SetActive(false);
                ResetDialogue();
            }
        }
    }


    void ResetDialogue(){
        _remainingTime = _displayTime;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if(objectToDisplay.name == "dialogue"){
            Debug.Log("objet à display: dialogue");
            PassengerInfoController.instance.GiveGift();
            _tempScript.GetScanner();// Monter le scanner
        }


        _isDisplaying = true ;


        if (!objectToDisplay.activeSelf)
        {
            objectToDisplay.SetActive(true);
            if(_audio!=null){
                _audio.Play();
            }
        }


       
    }
}


