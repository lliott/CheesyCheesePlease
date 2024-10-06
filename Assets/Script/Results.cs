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
            Debug.Log("Notre Roi a pû fêter son anniversaire sans aucun problème. Bon travail.");
            _txt.text = "Notre Roi a pû fêter son anniversaire sans aucun problème. Bon travail.";
        } 
        else if (success ==0){
            Debug.Log("Par vos actions, le Roi a été assassiné. Vous êtes viré et condamné à mort.");
            _txt.text = "Par vos actions, le Roi a été assassiné. Vous êtes viré et condamné à mort.";
        } 
        else if(success > fails){
            Debug.Log("Une tentative d’empoisonnement à été déjouée grâce à nos agents. Nous vous avons à l'œil.");
            _txt.text= "Une tentative d’empoisonnement à été déjouée grâce à nos agents. Nous vous avons à l'œil.";
        }
        else if(fails > success){
            Debug.Log("Beaucoup de sachets de drogues ont été mis dans la nourriture de notre très cher Roi. Celui-ci à succombé. J’espère que vous êtes fier de vous.");
            _txt.text = "Beaucoup de sachets de drogues ont été mis dans la nourriture de notre très cher Roi. Celui-ci à succombé. J’espère que vous êtes fier de vous.";
        }
        else{
            Debug.Log("autant");
            _txt.text = "autant";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
