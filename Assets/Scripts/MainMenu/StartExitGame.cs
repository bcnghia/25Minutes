using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartExitGame : MonoBehaviour
{
    public void StartGameplay()
    {
        SceneManager.LoadScene("Gameplay1");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
