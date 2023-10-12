using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float attackSpeed;

    [SerializeField] private float damage;

    float timeUntilAttack;

    private void Update()
    {
        if (timeUntilAttack <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                animator.SetTrigger("Attack");
                timeUntilAttack = attackSpeed;
            }
        } else
        {
            timeUntilAttack -= Time.deltaTime;
        }
    }
}
