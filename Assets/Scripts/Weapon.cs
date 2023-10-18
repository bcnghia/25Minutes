using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Animator animator;

    //[SerializeField] private float damage;

    [SerializeField] private float attackSpeed = 1.5f; // Tốc độ đánh
    public float currentAttackSpeed;
    // lấy tốc độ đánh HIỆN TẠI, đề phòng người dùng được buff tốc độ đánh

    [SerializeField] float sizeWeapon;
    // ý tưởng là bắt đầu game cho cây kiếm nhỏ, damage nhỏ
    // nâng cấp kiếm thì nâng size kiếm, damage kiếm => auto mạnh

    [SerializeField] private AudioClip attackAudioClip; // Thêm trường AudioClip
    private AudioSource audioSource; // Thêm trường AudioSource

    bool isAttacking = false;

    private void Start()
    {
        currentAttackSpeed = attackSpeed;
        transform.localScale = new Vector3(sizeWeapon, sizeWeapon, sizeWeapon);
        animator = GetComponent<Animator>();

        // Gắn Audio Source cho script
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = attackAudioClip;

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

            //if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            //{
            //    transform.localScale = new Vector3(sizeWeapon, -sizeWeapon, 0);
            //} else
            //{
            //    transform.localScale = new Vector3(sizeWeapon, sizeWeapon, 0);
            //}
        }
    }
    IEnumerator AttackLoop(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            animator.SetBool("Attack", true);
            isAttacking = true;

            audioSource.Play();

            yield return new WaitForSeconds(0.5f);
            // Đoạn return này dùng để tránh setbool liên tục làm kiếm không đánh ra

            animator.SetBool("Attack", false);
            isAttacking = false;

            delay = currentAttackSpeed; // cập nhật lại tốc độ đáhn cho weapon
        }
    }
}