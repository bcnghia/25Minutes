using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullets : MonoBehaviour
{
    public float bulletSpeed;
    Vector2 _direction; // Hướng đạn bắn
    bool isReady; // Để biết khi nào hướng đạn được bắn
    Transform player; // Tham chiếu đến người chơi

    void Awake()
    {
        isReady = false;
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Start()
    {

    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }

    void Update()
    {
        if (isReady)
        {
            // Nếu có thể tìm thấy người chơi
            if (player != null)
            {
                // Hướng từ viên đạn đến người chơi
                Vector2 directionToPlayer = (player.position - transform.position).normalized;

                // Gán hướng di chuyển của đạn là hướng đến người chơi
                _direction = directionToPlayer;

                // Di chuyển theo hướng mới
                Vector2 position = transform.position;
                position += _direction * bulletSpeed * Time.deltaTime;
                transform.position = position;
            }
            else
            {
                Debug.LogError("Không tìm thấy đối tượng người chơi.");
            }
        }
    }
}
