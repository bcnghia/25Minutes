using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : BuffItems
{
    private Transform Player;
    protected override void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
    }

    protected override void Update()
    {
        if (PlayerItems.isMagnet == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, 0.3f);
        }
    }
}
