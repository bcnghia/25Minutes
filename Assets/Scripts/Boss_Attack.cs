using UnityEngine;

public class Boss_Attack : StateMachineBehaviour
{
    public float dashBoost;
    public float dashTime;
    public float skillCooldown = 10f;
    public float attackRange = 3f;
    private float _dashTime;
    private float _cooldownTimer;
    private bool isDashing = false;
    private bool isSkillOnCooldown = false;

    Transform boss;
    Rigidbody2D rigidbody;
    Enemies enemiesScript;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();
        enemiesScript = animator.GetComponent<Enemies>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Kiểm tra xem quái vật có đang ở trong trạng thái đánh không
        if (stateInfo.IsTag("Attack") || stateInfo.IsTag("Attack2") || stateInfo.IsTag("Skill"))
        {
            return; // Nếu đang đánh thì không làm gì cả
        }

        // Kiểm tra khoảng cách và chuyển đến Attack hoặc Attack2 ngẫu nhiên
        if (Vector2.Distance(boss.position, rigidbody.position) <= attackRange)
        {
            int randomAttack = Random.Range(0, 3); // Random giữa 0 và 2 (bao gồm 0, 1, 2)

            if (randomAttack == 0)
                animator.SetTrigger("Attack");
            else if (randomAttack == 1)
                animator.SetTrigger("Attack2");
            else
                animator.SetTrigger("Skill");
        }

        if (isSkillOnCooldown)
        {
            _cooldownTimer -= Time.deltaTime;

            if (_cooldownTimer <= 0)
            {
                isSkillOnCooldown = false;
            }
        }

        if (!isSkillOnCooldown)
        {
            int randomAttack = Random.Range(0, 3); // Random giữa 0 và 2 (bao gồm 0, 1, 2)

            if (randomAttack == 0)
                animator.SetTrigger("Attack");
            else if (randomAttack == 1)
                animator.SetTrigger("Attack2");
            else
                animator.SetTrigger("Skill");

            isDashing = true;
            _dashTime = dashTime;
            isSkillOnCooldown = true;
            _cooldownTimer = skillCooldown;
        }

        if (animator.GetBool("Skill") && _dashTime > 0 && isDashing)
        {
            Debug.Log("Kích hoạt kĩ năng");

            float moveSpeed = enemiesScript.moveSpeed;

            Vector2 dashDirection = ((Vector2)boss.position - (Vector2)rigidbody.position).normalized;
            Vector2 dashVelocity = new Vector2(dashDirection.x * moveSpeed, rigidbody.velocity.y);
            rigidbody.velocity = dashVelocity;
        }

        if (_dashTime <= 0 && isDashing)
        {
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
        animator.ResetTrigger("Skill");
    }
}
