using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Temperature : MonoBehaviour, IPointerClickHandler
{
    [Header("UI")]
    [SerializeField] private Image _screen;
    [SerializeField] private Text _degreeTxt;
    [SerializeField] private Text _txtInterdictions;
    [SerializeField] private Sprite _redScreen;
    [SerializeField] private Sprite _greenScreen;

    [Header("Timer")]
    [SerializeField] private float _displayTime = 2;
    public float remainingTime;
    private bool _isDisplaying = false;

    //Random
    private int chance;
    private int randomDegree;
    [SerializeField] private List<int> randomInterdictions=new List<int>();

    private bool available = true; //Passenger valide

    void Start(){
        DisplayInterdictions() ;
        ResetThermometer();
    }

    public void Update(){
        if(_isDisplaying){
            if(remainingTime>0){
                remainingTime -= Time.deltaTime;
            } else{
                ResetThermometer();
            }
        }
    }

    private void ResetThermometer(){
        _isDisplaying = false ;
        remainingTime = _displayTime;
        _screen.gameObject.SetActive(false);
        _degreeTxt.text = null;
    }

    //Appelée au début de chaque round
    public void GenerateResults(){
        //Reset available à chq round
        ResetThermometer();
        available = true; 

        //Generate new temperature
        chance = Random.Range(1,11); //11 exclut 
        if(chance<=2){                   // = 2/10 chances
            available = false;
        }
        randomDegree = Random.Range(5,81);
    }

    public void OnPointerClick(PointerEventData eventData)
    { 
        _isDisplaying = true;

        //Print a randomDegree
        UpdateUI();
        
        _screen.gameObject.SetActive(true);
        if(!available){
            _screen.sprite = _redScreen;
        } else{
            _screen.sprite = _greenScreen;
            available = GetInterdictions();
        }

    }

    public void GetFourRandomInterdictions(){
        for (int i = 0; i < 4; i++){
            GenerateRandomInterdictions();
        }
    }
    public void GenerateRandomInterdictions(){
        int a;
        bool firstRange = Random.value < 0.5f; // 50% chance pr chq plage de valeurs

        if (firstRange)
        {
            a = Random.Range(5, 25);      
        }
        else
        {
            a = Random.Range(51, 81);
        }
        
        //Check si y a pas de doublons
        if(randomInterdictions.Count != 0){  
            foreach(var randomInterdiction in randomInterdictions){
                    if ( a == randomInterdiction){
                        Debug.Log("Recalcule");
                        GenerateRandomInterdictions();
                        return;
                    }
                }
        }
        randomInterdictions.Add(a); 
    }

    private bool GetInterdictions(){
        if(randomDegree>=25 && randomDegree <= 50){
            return true;
        }
        foreach(var value in randomInterdictions){
            if(randomDegree == value ){
                Debug.Log("interdit"+randomDegree);
                return false;
            }
        }
        return true;
    }

    private void DisplayInterdictions(){
        _txtInterdictions.text ="UNAUTHORISED TEMPERATURES: \n";
        foreach(var value in randomInterdictions){
            _txtInterdictions.text += value + "°C\n";
        }
    }

    private void UpdateUI(){
        _degreeTxt.text = randomDegree.ToString() + "°";
    }

    //A appeler ds la verif finale à la fin de chq round
    public bool isTemperatureCorrect(){
        if(available){
            return true;
        }
        return false;
    }
}
