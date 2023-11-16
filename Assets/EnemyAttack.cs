using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
    public float attackRange = 4f;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        // Kiểm tra khoảng cách giữa quái và người chơi
        if (Vector2.Distance(animator.transform.position, player.position) <= attackRange)
        {
            // Khi đạt đến khoảng cách mong muốn, kích hoạt trigger "Attack"
            animator.SetTrigger("Attack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
