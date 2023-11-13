using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject soundBackground;
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject levelUpPanel;

    bool activeLevelUp;

    void Start()
    {
        pauseMenu.SetActive(false);
        activeLevelUp = levelUpPanel.GetComponent<ActivePanel>().isSetActive;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // Đang nâng cấp thì không được ESC thoát ra
            activeLevelUp = levelUpPanel.GetComponent<ActivePanel>().isSetActive;
            if (!activeLevelUp)
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        soundBackground.SetActive(false);

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        soundBackground?.SetActive(true);

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}