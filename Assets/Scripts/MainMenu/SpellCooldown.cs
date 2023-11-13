using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellCooldown : MonoBehaviour
{
    public float dashBoost;
    // Thời gian có thể lướt
    public float dashTime;
    // Tiến trình thời gian lướt
    float dashTimer;
    bool isDashing = false;

    bool canDash = true;
    // Cooldown - thời gian hồi chiêu 
    public float dashCooldownTime = 3f;

    public TMP_Text textCooldown;
    public Image imageCooldown;

    public GameObject ghostEffect;
    public float ghostDelaySeconds;
    private Coroutine dashEffectCoroutine;

    GameObject player;
    PlayerMovement playerMove;
    private void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0f;

        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMovement>();
    }

    public void Continue()
    {
        gameObject.SetActive(true);
        StartCoroutine(DashCooldown(int.Parse(textCooldown.text)-1));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseSpell();
        }

        if (dashTimer <= 0 && isDashing == true)
        {
            playerMove.moveSpeed -= dashBoost;
            isDashing = false;
            StopDashEffect();
        }

        else
        {
            dashTimer -= Time.deltaTime;
        }
    }

    public void UseSpell()
    {
        if (canDash)
        {
            playerMove.moveSpeed += dashBoost;
            dashTimer = dashTime;
            isDashing = true;
            StartDashEffect();

            // Không cho phép sử dụng Dash trong khoảng thời gian cooldown
            StartCoroutine(DashCooldown(dashCooldownTime));
        }
    }

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
            GameObject ghost = Instantiate(ghostEffect, player.transform.position, player.transform.rotation);
            Sprite currentSprite = player.GetComponent<SpriteRenderer>().sprite;
            ghost.GetComponent<SpriteRenderer>().sprite = currentSprite;

            Destroy(ghost, 0.5f);
            yield return new WaitForSeconds(ghostDelaySeconds);
        }
    }

    // Hàm cooldown Dash
    IEnumerator DashCooldown(float cooldown)
    {
        // Tạm thời vô hiệu hóa Dash
        canDash = false;
        textCooldown.gameObject.SetActive(true);

        float currentTime = cooldown;
        while (currentTime > 0)
        {
            textCooldown.text = Mathf.RoundToInt(currentTime).ToString();
            imageCooldown.fillAmount = currentTime / dashCooldownTime;
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0f;
        canDash = true;  // Cho phép sử dụng lại Dash
    }
}
