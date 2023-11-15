using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuContainer;
    [SerializeField] private GameObject settingContainer;

    bool isActiveChild = false;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isActiveChild)
            {
                ExitSetting();
            }
        }
    }

    public void StartGameplay()
    {
        SceneManager.LoadScene("Gameplay1");
    }

    public void SettingsGame()
    {
        isActiveChild = true;

        menuContainer.SetActive(false);
        settingContainer.SetActive(true);
    }

    public void ExitSetting()
    {
        isActiveChild = false;

        menuContainer.SetActive(true);
        settingContainer.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
