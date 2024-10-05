using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChecking : MonoBehaviour
{
    [SerializeField] private TerroristInfoController _terroristInfoController;
    [SerializeField] private Temperature _temperatureScript;

    //Accepter passenger
    public void Accept(){
        Check(true);
        RoundManager.instance.ShowNextPassenger();
    }

    //Refuser passenger
    public void Refuse(){
        Check(false);
        RoundManager.instance.ShowNextPassenger();
    }

    private void Check(bool response){
        bool result = true ;
        if(_terroristInfoController.isTerrorist()){
            Debug.Log("est terroriste");
            result = false ;
        }else{
            Debug.Log("pas terroriste");
        }
        if(!_temperatureScript.isTemperatureCorrect()){
            Debug.Log("mauvaise température");
            result = false ;
        }else{
            Debug.Log("good température");
        }
        
        if(result == response){
            Debug.Log("Gagné pr ce rat");
        } else{
            Debug.Log("Perdu");
        }

    }
}
