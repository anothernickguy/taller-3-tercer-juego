using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Nombre de la escena a cargar
    public string sceneName;

    // Funci�n para cargar la escena usando el nombre de la escena como par�metro
    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    // Funci�n para cargar la escena usando una variable de clase como nombre de la escena
    public void LoadSceneByVariable()
    {
        SceneManager.LoadScene(sceneName);
    }

    // Funci�n para salir del juego
    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
