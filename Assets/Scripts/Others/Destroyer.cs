using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform player;

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;

            if (direction.x < 0)
            {
                // Nếu người chơi ở bên phải, flip sprite qua phải
                spriteRenderer.flipX = false;
            }
            else if (direction.x > 0)
            {
                // Nếu người chơi ở bên trái, không flip sprite
                spriteRenderer.flipX = true;
            }
        }
    }
}
