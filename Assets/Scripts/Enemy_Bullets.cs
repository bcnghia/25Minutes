using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullets : MonoBehaviour
{
    public float bulletSpeed;
    Vector2 _direction; // Hướng đạn bắn
    bool isReady; // Để biết khi nào hướng đạn được bắn
    

    void Awake()
    {
        isReady = false;
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
            Vector2 position = transform.position;
            position += _direction * bulletSpeed * Time.deltaTime;
            transform.position = position;
        }

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
           (transform.position.y < min.y) || (transform.position.y > max.y))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerShip")
        {
            Destroy(gameObject);
        }
    }
}
