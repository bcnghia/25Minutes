using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 moveDir;

    public static bool isMagnet = false;
    private float magnetDuration = 3.0f; // Độ dài thời gian hút (5 giây)
    private float magnetTimer = 0.0f; // Thời gian đếm ngược khi đang hút



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move(); // Xử lý hút

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


    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0 || moveDir.y != 0)
        {
            animator.SetFloat("Horizontal", moveDir.x);
            animator.SetFloat("Vertical", moveDir.y);

            animator.SetBool("IsWalking", true);
        }
        else animator.SetBool("IsWalking", false);
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
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
