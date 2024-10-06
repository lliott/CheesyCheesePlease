using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Temperature : MonoBehaviour, IPointerClickHandler
{
    //UI
    [SerializeField] private Image _screen;
    [SerializeField] private Text _degreeTxt;
    [SerializeField] private Text _txtInterdictions;

    //Timer 
    [SerializeField] private float _displayTime = 2;
    public float remainingTime;
    private bool _isDisplaying = false;

    //Random
    private int chance;
    private int randomDegree;

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
        _screen.color = Color.white;
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
        randomDegree = Random.Range(25,50);
    }

    public void OnPointerClick(PointerEventData eventData)
    { 
        _isDisplaying = true;

        //Print a randomDegree
        UpdateUI();

        if(!available){
            _screen.color = Color.red;
        } else{
            _screen.color = Color.green; 
            available = GetInterdictions();
        }

    }

    private bool GetInterdictions(){
        if(randomDegree==28 || randomDegree==41 || randomDegree==35 || randomDegree==47 ){
            Debug.Log("interdit"+randomDegree);
            return false;
        }
        return true;
    }

    private void DisplayInterdictions(){
        _txtInterdictions.text=" Registre des interdictions de températures \n 28, 41,35,47";
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
