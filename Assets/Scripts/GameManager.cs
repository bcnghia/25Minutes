using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject playButton;
    //public GameObject playerShip;

    public GameObject enemy01Spawner;
    //public GameObject enemy02Spawner;
    //public GameObject enemy03Spawner;
    //public GameObject enemy04Spawner;

    //public GameObject GameOver;
    //public GameObject scoreUIText;
    //public GameObject exitButton;

    //public enum GameManagerState
    //{
    //    Opening, Gameplay, GameOver, Exit
    //}

    //GameManagerState GMS;

    void Start()
    {
        enemy01Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
    }

    //void UpdateGameManagerState()
    //{
    //    switch (GMS)
    //    {
    //        case GameManagerState.Opening:
    //            playerShip.SetActive(false); // Ẩn tàu người chơi khi trò chơi bắt đầu
    //            playButton.SetActive(true); // Hiện nút bắt đầu game khi vào trò chơi
    //            GameOver.SetActive(false); // Ẩn màn hình game over
    //            exitButton.SetActive(true);

    //            break;

    //        case GameManagerState.Gameplay:
    //            playButton.SetActive(false);
    //            exitButton.SetActive(false);
    //            playerShip.SetActive(true);

    //            playerShip.GetComponent<Player>().Init(); // Thanh máu khi chưa nhấn có màu đỏ biểu thị cho mặc định
    //                                                      // và nhấn vào thì sẽ có màu xanh (bắt đầu chơi)

    //            enemy01Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
    //            enemy02Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
    //            enemy03Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
    //            enemy04Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();

    //            scoreUIText.GetComponent<GameScore>().Score = 0;

    //            break;

    //        case GameManagerState.GameOver:
    //            // Dừng việc spawn kẻ địch và Hiển thị màn hình kết thúc (Game Over)
    //            enemy01Spawner.GetComponent<EnemySpawner>().Stopspawning();
    //            enemy02Spawner.GetComponent<EnemySpawner>().Stopspawning();
    //            enemy03Spawner.GetComponent<EnemySpawner>().Stopspawning();
    //            enemy04Spawner.GetComponent<EnemySpawner>().Stopspawning();

    //            playerShip.SetActive(false);

    //            GameOver.SetActive(true);

    //            Invoke("ChangeToOpeningState", 3f); // nút play sẽ xuất hiện trở lại thời gian đã cài đặt

    //            break;
    //    }
    //}

    //public void SetGameManagerState(GameManagerState state)
    //{
    //    GMS = state;
    //    UpdateGameManagerState();
    //}

    //public void StarGamePlay()
    //{
    //    GMS = GameManagerState.Gameplay;
    //    UpdateGameManagerState();

    //}

    //public void ChangeToOpeningState()
    //{
    //    SetGameManagerState(GameManagerState.Opening);
    //}

    //public void ExitGame()
    //{
    //    Application.Quit();
    //    Debug.Log("Quit");
    //}

}
