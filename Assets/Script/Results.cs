using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public static Results instance;

    [Header("Results")]
    public int fails;
    public int success;

    [Header("UI")]
    [SerializeField] private GameObject UIGame;
    [SerializeField] private GameObject UIResult;
    [SerializeField] private Text _txt;

    
    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        UIResult.SetActive(false);
    }

    public void ConcludeGame(){
        
        UIGame.SetActive(false);
        UIResult.SetActive(true);

        if(fails==0){
            Debug.Log("Our king held a magnificent feast, and all was well, thanks to you.");
            _txt.text = "Our king held a magnificent feast, and all was well, thanks to you.";
        } 
        else if (success ==0){
            Debug.Log("By your actions, our liege died in the hands of an assassin, you will be strung like cheese and hung.");
            _txt.text = "By your actions, our liege died in the hands of an assassin, you will be strung like cheese and hung.";
        } 
        else if(success > fails){
            Debug.Log("An assassin attempted to sneak poison to our Lords meal, but was caught in the act. We have our eye on you.");
            _txt.text= "An assassin attempted to sneak poison to our Lords meal, but was caught in the act. We have our eye on you.";
        }
        else if(fails > success){
            Debug.Log("Our Lord has succumbed to food poisoning, oh the tragedy! This is all your doing...!");
            _txt.text = "Our Lord has succumbed to food poisoning, oh the tragedy! This is all your doing...!";
        }
        else{
            Debug.Log("It would seem a balance was made.");
            _txt.text = "It would seem a balance was made.";
        }
    }
}
