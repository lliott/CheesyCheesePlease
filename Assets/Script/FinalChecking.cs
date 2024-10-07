using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinalChecking : MonoBehaviour
{
    public static FinalChecking instance;
    [SerializeField] private TerroristInfoController _terroristInfoController;
    [SerializeField] private PassengerData _passengerData;
    [SerializeField] private RoundManager _roundManager;
    [SerializeField] private Temperature _temperatureScript;
    [SerializeField] private Offrandes _offrandesScript;
    private AudioSource[] _audio = new AudioSource[4];


    void Start(){
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
       
        _audio = GetComponents<AudioSource>();
    }


    //Accepter passenger
    public void Accept(){
        Check(true);
        RoundManager.instance.ShowNextPassenger();
        _roundManager.isAccepted = true;
        _audio[2].Play();
        _audio[3].Play();
    }


    //Refuser passenger
    public void Refuse(){
        Check(false);
        RoundManager.instance.ShowNextPassenger();
        _roundManager.isAccepted = false;
        _audio[0].Play();
        _audio[1].Play();
    }


    private void Check(bool response){
        bool result = true ;
        if(_terroristInfoController.isTerrorist()){
            Debug.Log("est terroriste");
            result = false ;
        }else{
            Debug.Log("pas terroriste");
        }
        if (_terroristInfoController.isWrongID())
        {
            Debug.Log("ID is wrong");
            result = false;
        }
        else
        {
            Debug.Log("id est correcte");
        }
        if (!_temperatureScript.isTemperatureCorrect()){
            Debug.Log("mauvaise température");
            result = false ;
        }else{
            Debug.Log("good température");
        }
        if(!_offrandesScript.isOffrandeCorrect()){
            Debug.Log("offrande interdite");
            result = false ;
        }else{
            Debug.Log("good offrande");
        }
       
        if(result == response){
            Debug.Log("Gagné pr ce rat");
            Results.instance.success++;
        } else{
            Debug.Log("Perdu");
            Results.instance.fails++;
        }


    }
}
