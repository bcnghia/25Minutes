using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject skill1Button;
    [SerializeField] private GameObject pauseContainer;
    [SerializeField] private GameObject settingContainer;

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
        //SoundManager.Instance.ToggleMusic();
        skill1Button.SetActive(false);

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        //SoundManager.Instance.ToggleMusic();
        skill1Button.GetComponent<SpellCooldown>().Continue();

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SettingsGame()
    {
        pauseContainer.SetActive(false);
        settingContainer.SetActive(true);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}