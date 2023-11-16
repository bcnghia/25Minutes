using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 moveDir;

    float ratioSPD = 0f;

    public float minX, maxX, minY, maxY;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        InputManagement();
        ClampPosition(); // Thêm hàm này để giới hạn vị trí của người chơi
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

    void ClampPosition()
    {
        // Lấy vị trí hiện tại của người chơi
        Vector3 currentPosition = transform.position;

        // Giới hạn vị trí theo chiều X và Y
        float clampedX = Mathf.Clamp(currentPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(currentPosition.y, minY, maxY);

        // Gán lại vị trí sau khi được giới hạn
        transform.position = new Vector3(clampedX, clampedY, currentPosition.z);
    }

    public void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
    
    public void SetRatioSPD(float ratio)
    {
        ratioSPD += ratio;
    }

    public float GetRatioSPD() { return ratioSPD; }
}
