using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float currentHealth, maxHealth;
    [SerializeField] private float currentExperience, maxExperience;
    [SerializeField] private int currentLevel = 1;

    public HealthBar healthBar;
    public ExperienceBar experienceBar;
    public Text level;

    public bool isAttacking; // Tạo biến để xác định trạng thái tấn công

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        level.text = "LV : " + currentLevel;

        currentExperience = 0;
        experienceBar.SetExperience(currentExperience);
        experienceBar.SetMaxExperience(maxExperience);

        isAttacking = false; // Ban đầu đặt trạng thái tấn công là false

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            // Kiểm tra xem người chơi đang tấn công (đang va chạm với quái) hay không
            Player player = collision.GetComponent<Player>(); // Tìm đối tượng Player trong collider
            if (player != null && player.isAttacking)
            {
                collision.GetComponent<Enemies>().TakeDamage(5);
            }
        }
    }

    // Thêm phương thức để hồi máu
    public void Healing()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 0.2f * maxHealth;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            healthBar.SetHealth(currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("YOU ARE DEATH: " + damage);
        }
    }

    public void IncreaseExp(float newExperience)
    {
        currentExperience += newExperience;
        experienceBar.SetExperience(currentExperience);
        if(currentExperience >= maxExperience)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        maxHealth += 10; // có thể đặt biến để tùy chỉnh ở ngoài
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        //currentHealth = maxHealth; // hồi máu khi nâng cấp

        currentLevel++;
        level.text = "LV : " + currentLevel;

        currentExperience = 0;
        experienceBar.SetExperience(currentExperience);
        maxExperience += 100; // có thể đặt biến để tùy chỉnh ở ngoài
        experienceBar.SetMaxExperience(maxExperience);
    }
}
