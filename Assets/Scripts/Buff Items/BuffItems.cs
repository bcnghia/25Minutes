using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItems : MonoBehaviour
{
    private Transform Player;
    protected virtual void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
    }

    protected virtual void Update()
    {
        // Tự Edit
    }
}
