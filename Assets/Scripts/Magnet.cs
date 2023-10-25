using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private Transform Player;
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (PlayerMovement.isMagnet == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, 0.3f);
        }
    }
}
