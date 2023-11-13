using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;


    public float dashBoost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;


    private bool canDash = true; 
    public float dashCooldown = 3f;  // Cooldown cho nút dash


    public GameObject ghostEffect;
    public float ghostDelaySeconds;
    private Coroutine dashEffectCoroutine;

    Vector2 moveDir;

    float ratioSPD = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        InputManagement();


        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            moveSpeed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;
            StartDashEffect();

            // Không cho phép sử dụng Dash trong khoảng thời gian cooldown
            StartCoroutine(DashCooldown());
        }

        if (_dashTime <= 0 && isDashing == true)
        {
            moveSpeed -= dashBoost;
            isDashing = false;
            StopDashEffect();
        }

        else
        {
            _dashTime -= Time.deltaTime;
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
    public void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
    
    public void SetRatioSPD(float ratio)
    {
        ratioSPD += ratio;
    }

    public float GetRatioSPD() { return ratioSPD; }

    void StartDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
        dashEffectCoroutine = StartCoroutine(DashEffectCoroutine());
    }

    void StopDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
    }

    IEnumerator DashEffectCoroutine()
    {
        while (true)
        {
            GameObject ghost = Instantiate(ghostEffect, transform.position, transform.rotation);
            Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
            ghost.GetComponent<SpriteRenderer>().sprite = currentSprite;

            Destroy(ghost, 0.5f);
            yield return new WaitForSeconds(ghostDelaySeconds);
        }
    }

    // Hàm cooldown Dash
    IEnumerator DashCooldown()
    {
        canDash = false;  // Tạm thời vô hiệu hóa Dash

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;  // Cho phép sử dụng lại Dash
    }
}
