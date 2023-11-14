using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public float attackSpeed = 1.5f; // Tốc độ đánh
    public float currentAttackSpeed;
    // lấy tốc độ đánh HIỆN TẠI, đề phòng người dùng được buff tốc độ đánh

    public float sizeWeapon;

    public string sfxClipName;

    bool isAttacking = false;

    float ratioAttackSpeed = 0f;
    float ratioSizeWeapon = 0f;

    private void Start()
    {
        currentAttackSpeed = attackSpeed;
        transform.localScale = new Vector3(sizeWeapon, sizeWeapon, sizeWeapon);
        animator = GetComponent<Animator>();

        StartCoroutine(AttackLoop(currentAttackSpeed));
    }

    private void Update()
    {
        RotateSword();
        if (currentAttackSpeed != attackSpeed)
        {
            currentAttackSpeed = attackSpeed;
        }
    }

    void RotateSword()
    {
        if (!isAttacking) // Chỉ xoay khi kiếm không tấn công
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mousePos - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;
        }
    }
    IEnumerator AttackLoop(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            animator.SetBool("Attack", true);
            isAttacking = true;

            SoundManager.Instance.PlaySFX(sfxClipName);

            yield return new WaitForSeconds(0.5f);
            // Đoạn return này dùng để tránh setbool liên tục làm kiếm không đánh ra

            animator.SetBool("Attack", false);
            isAttacking = false;

            delay = currentAttackSpeed; // cập nhật lại tốc độ đáhn cho weapon
        }
    }

    public void SetRatioAttackSpeed(float ratio)
    {
        ratioAttackSpeed += ratio;
    }

    public void SetRatioSizeWeapon(float ratio)
    {
        ratioSizeWeapon += ratio;
    }

    public float GetRatioAttackSpeed() { return ratioAttackSpeed; }

    public float GetRatioSizeWeapon() { return ratioSizeWeapon; }
}