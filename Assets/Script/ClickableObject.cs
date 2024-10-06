using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject objectToDisplay;
    [SerializeField] private float _displayTime;
    private float _remainingTime ;
    private bool _isDisplaying = false;

    void Awake()
    {
        objectToDisplay.SetActive(false); 
        ResetDialogue() ;
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
        }

        _isDisplaying = true ;

        if (!objectToDisplay.activeSelf)
        {
            objectToDisplay.SetActive(true);
        }

        
    }
}
