using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : BuffItems
{
    Player player;

    protected override void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
        if (collision.tag == "Player")
        {
            player.Healing();
            Debug.Log("HEALING " + collision.tag);
        }
    }
}
