using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float attackSpeed; // đang k dùng

    [SerializeField] private float damage;

    float timeUntilAttack; // đang k dùng

    [SerializeField] float sizeSword; 
    // ý tưởng là bắt đầu game cho cây kiếm nhỏ, damage nhỏ
    // nâng cấp kiếm thì nâng size kiếm, damage kiếm => auto mạnh

    private void Update()
    {
        RotateSword();

        

        //if (timeUntilAttack <= 0)
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        animator.SetTrigger("Attack");
        //        timeUntilAttack = attackSpeed;
        //    }
        //} else
        //{
        //    timeUntilAttack -= Time.deltaTime;
        //}
    }

    public float GetDamage()
    {
        return damage;
    }

    private void SetDamage(float value)
    {
        damage = value;
    }

    void RotateSword()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(sizeSword, -sizeSword, 0);
        } else
        {
            transform.localScale = new Vector3(sizeSword, sizeSword, 0);
        }
    }
}
