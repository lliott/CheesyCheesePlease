using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadSceneAsync("GP_Ambre+Elliott1");
    }

    public void Quit(){
        Application.Quit();
    }
}
