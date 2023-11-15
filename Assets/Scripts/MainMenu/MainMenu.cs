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
        // Sau này làm thêm tính năng chọn màn thì có thể LoadScene đó lên rồi load cả nhạc trùng với tên
        SoundManager.Instance.PlayMusic("GamePlay1");

        Time.timeScale = 1.0f;
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
