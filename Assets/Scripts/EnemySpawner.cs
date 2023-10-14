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
        // dưới - trái điểm trên màn hình
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // trên - phải 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(enemies);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

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
