using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemies;

    [SerializeField]
    private int enemyApproach; // Thiết lập giá trị mặc định

    void Start()
    {

    }

    public void SetCustomSpawnRate(int rate)
    {
        enemyApproach = rate;
    }

    void Update()
    {

    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(enemies);

        Vector3 spawnPosition = Vector3.zero;
        float randomSide = Random.Range(0, 8);

        switch (randomSide)
        {
            case 0: // Bên trên
                spawnPosition = new Vector2(Random.Range(min.x, max.x), max.y);
                break;
            case 1: // Bên dưới
                spawnPosition = new Vector2(Random.Range(min.x, max.x), min.y);
                break;
            case 2: // Bên trái
                spawnPosition = new Vector2(min.x, Random.Range(min.y, max.y));
                break;
            case 3: // Bên phải
                spawnPosition = new Vector2(max.x, Random.Range(min.y, max.y));
                break;
            case 4: // Điểm góc trên bên trái
                spawnPosition = new Vector2(min.x, max.y);
                break;
            case 5: // Điểm góc trên bên phải
                spawnPosition = new Vector2(max.x, max.y);
                break;
            case 6: // Điểm góc dưới bên trái
                spawnPosition = new Vector2(min.x, min.y);
                break;
            case 7: // Điểm góc dưới bên phải
                spawnPosition = new Vector2(max.x, min.y);
                break;
        }

        anEnemy.transform.position = spawnPosition;
        ScheduleNextEnemySpawn();
    }


    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;
        if (enemyApproach > 1f)
        {
            spawnInSeconds = Random.Range(enemyApproach, 1f);
        }
        else
        {
            spawnInSeconds = 1f;
        }

        Invoke("SpawnEnemy", spawnInSeconds);
    }


    void IncreaseSpawnRate()
    {
        // Tăng thêm tỉ lệ sinh ra quái theo thời gian dựa theo thời gian mà enemyApproach được đặt, giảm đi 1 
        if (enemyApproach > 1f)
        {
            enemyApproach--;
        }
        if (enemyApproach == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

    public void ScheduleEnemySpawner()
    {
        // tăng tốc quá trình sinh ra quái cứ mỗi 2 phút
        Invoke("SpawnEnemy", enemyApproach);


        InvokeRepeating("IncreaseSpawnRate", 0f, 120f);
    }


    public void Stopspawning()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
