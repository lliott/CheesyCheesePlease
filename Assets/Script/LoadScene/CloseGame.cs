using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
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

