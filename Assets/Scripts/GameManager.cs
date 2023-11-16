using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject enemy01Spawner;
    public GameObject enemy02Spawner;
    public GameObject enemy03Spawner;
    public GameObject enemy04Spawner;
    public GameObject enemy05Spawner;
    public GameObject enemy06Spawner;
    public GameObject enemy07Spawner;

    void Start()
    {
        enemy01Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
        enemy02Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
        enemy03Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
        enemy04Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
        enemy05Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
        enemy06Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
        enemy07Spawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
    }
}
