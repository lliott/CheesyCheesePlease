using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitGame : MonoBehaviour
{
        private AudioSource _audio; 

        void Start(){
                if(gameObject.GetComponent<AudioSource>() != null)
                {      
                _audio = GetComponent<AudioSource>();
                }
        }

    public void Quit()
    {
        if(_audio!=null){
            _audio.Play();
        }
        Invoke("Quitter",0.25f);
    }

    private void Quitter(){
        // if in a standalone build
        #if UNITY_STANDALONE
                // quit application
                Application.Quit();
        #endif

                // if running in the editor
        #if UNITY_EDITOR
                // stop playing the scene
                EditorApplication.isPlaying = false;
        #endif
    }
}

