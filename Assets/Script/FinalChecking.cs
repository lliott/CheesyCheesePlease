using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChecking : MonoBehaviour
{
    [SerializeField] private TerroristInfoController _terroristInfoController;
    [SerializeField] private Temperature _temperatureScript;

    //Accepter passenger
    public void Accept(){
        Check();
    }

    //Refuser passenger
    public void Refuse(){
        Check();
    }

    private void Check(){
        if(_terroristInfoController.isTerrorist()){
            Debug.Log("est terroriste");
        }
        if(!_temperatureScript.isTemperatureCorrect()){
            Debug.Log("mauvaise température");
        }
    }
}
