using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGameplay()
    {
        SceneManager.LoadScene("Gameplay1");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
