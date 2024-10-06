using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChecking : MonoBehaviour
{
    [SerializeField] private TerroristInfoController _terroristInfoController;
    [SerializeField] private Temperature _temperatureScript;
    [SerializeField] private Offrandes _offrandesScript;

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
