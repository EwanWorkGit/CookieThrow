using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    public void ExitToMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
    #if (UNITY_EDITOR)
               UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
}
