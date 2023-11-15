using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : StateMachineBehaviour
{
    Enemies enemiesScript;
    public float attackRange = 3f;
    public float dashBoost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;

    Transform player;
    Rigidbody2D rigidbody;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();
        enemiesScript = animator.GetComponent<Enemies>(); // Gán tham chiếu đến script Enemies
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveSpeed = enemiesScript.moveSpeed;
        Vector2 target = new Vector2(player.position.x, rigidbody.position.y);

        if (Vector2.Distance(player.position, rigidbody.position) <= attackRange)
        {
            int randomAttack = Random.Range(0, 3); // Random từ 0 đến 2

            if (randomAttack == 0)
                animator.SetTrigger("Attack");
            else if (randomAttack == 1)
                animator.SetTrigger("Attack2");
            else
                animator.SetBool("Skill", true);
        }


        // Sử dụng "GetBool" để kiểm tra nếu "Skill" đang được kích hoạt
        if (animator.GetBool("Skill") && _dashTime <= 0 && !isDashing)
        {
            moveSpeed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;
        }

        if (_dashTime <= 0 && isDashing == true)
        {
            moveSpeed -= dashBoost;
            isDashing = false;
        }
        else
        {
            _dashTime -= Time.deltaTime;
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Attack2");
        animator.SetBool("Skill", false);
    }
}
