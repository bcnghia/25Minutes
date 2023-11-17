using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    PlayerMovement pm;
    public Rigidbody2D rb;
    
    public static bool isMagnet = false;
    private float magnetDuration = 3.0f; // Độ dài thời gian hút
    private float magnetTimer = 0.0f; // Thời gian đếm ngược khi đang hút

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
    }

    void FixedUpdate()
    {
        pm.Move(); // Xử lý hút
        ///////////////////////////////////////////////////////////////////
        if (isMagnet && magnetTimer > 0)
        {   
            magnetTimer -= Time.fixedDeltaTime; // Đếm ngược thời gian
        }
        else
        {
            // Khi hết thời gian hút, tắt Magnet
            isMagnet = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Magnet")
        {
            isMagnet = true;
            magnetTimer = magnetDuration;
        }
    }
}
