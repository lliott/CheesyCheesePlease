using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private AudioSource _audio;

    [SerializeField] private int sceneIndex;

    void Start(){
        if(gameObject.GetComponent<AudioSource>() != null)
        {      
        _audio = GetComponent<AudioSource>();
        }
    }

    public void LoadSceneByIndex()
    {
        if(_audio!=null){
            _audio.Play();
        }
        Invoke("LoadSceneA",0.25f);
    }

    private void LoadSceneA(){
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.Log("No scene chosen in index, or out of range");
        }
    }

}
