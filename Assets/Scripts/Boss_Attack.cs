using UnityEngine;

public class Boss_Attack : StateMachineBehaviour
{
    public float detectionRange = 5f;
    public float dashBoost;
    public float dashTime;
    public float skillCooldown = 10f;
    private float _dashTime;
    private float _cooldownTimer;
    private bool isDashing = false;
    private bool isSkillOnCooldown = false;

    Transform player;
    Rigidbody2D rigidbody;
    Enemies enemiesScript;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();
        enemiesScript = animator.GetComponent<Enemies>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isSkillOnCooldown)
        {
            _cooldownTimer -= Time.deltaTime;

            if (_cooldownTimer <= 0)
            {
                isSkillOnCooldown = false;
            }
        }

        // Kiểm tra xem người chơi có nằm trong khoảng nhìn thấy hay không và cooldown đã kết thúc
        if (Vector2.Distance(player.position, rigidbody.position) <= detectionRange && !isSkillOnCooldown)
        {
            animator.SetTrigger("Skill");
            isDashing = true;
            _dashTime = dashTime;
            isSkillOnCooldown = true;
            _cooldownTimer = skillCooldown; 
        }

        // Sử dụng "GetBool" để kiểm tra nếu "Skill" đang được kích hoạt
        if (animator.GetBool("Skill") && _dashTime > 0 && isDashing)
        {
            Debug.Log("Kích hoạt kĩ năng");

            float moveSpeed = enemiesScript.moveSpeed; // Lấy tốc độ di chuyển từ script Enemies

            // Xác định hướng người chơi để jumpscary
            Vector2 dashDirection = ((Vector2)player.position - (Vector2)rigidbody.position).normalized;
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
        animator.ResetTrigger("Skill");
    }
}
