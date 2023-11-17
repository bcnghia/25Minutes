using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
    public float attackRange = 4f;
    Transform player;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        } catch { }

        // Kiểm tra khoảng cách giữa quái và người chơi
        if (player != null)
        {
            if (Vector2.Distance(animator.transform.position, player.position) <= attackRange)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
