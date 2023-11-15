using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject ui;
    public GameObject levelUpPanel;
    public GameObject skill1Button;
    public GameObject hpExp;

    [SerializeField] private float currentHealth, maxHealth;
    [SerializeField] private float currentExperience, maxExperience;
    [SerializeField] private int currentLevel = 1;

    public HealthBar healthBar;
    public ExperienceBar experienceBar;
    //public Text level;

    public bool isAttacking; // Tạo biến để xác định trạng thái tấn công
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
        //healthBar.SetMaxHealth(maxHealth);
        //level.text = "LV : " + currentLevel;
        //health.text = currentHealth.ToString() + " / " + maxHealth.ToString();

        currentExperience = 0;
        experienceBar.SetExperience(currentExperience,currentLevel);
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
            healthBar.SetHealth(currentHealth,maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth, maxHealth);
            //Destroy(gameObject);
            gameObject.SetActive(false);
            ui.GetComponent<GameoverMenu>().GameOver();
            Debug.Log("YOU ARE DEATH: " + damage);
        }
        else
        {
            healthBar.SetHealth(currentHealth,maxHealth);
        }
    }

    // thêm phương thức để hút máu. amountBlood == là số máu hút được -> lượng máu này được dùng để cộng vào máu hiện tại
    public void LifeSteal(float amountBlood)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amountBlood;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            healthBar.SetHealth(currentHealth, maxHealth);
        }
    }

    public void IncreaseExp(float newExperience)
    {
        currentExperience += newExperience;
        experienceBar.SetExperience(currentExperience, currentLevel);
        if(currentExperience >= maxExperience)
        {
            LevelUp();
            // Lấy thông tin Buff Item
            ui.GetComponent<LevelUpMenu>().GetRandomBuffItem();
            // Hiện panel lvl Up sau khi đã load được Buff Item
            levelUpPanel.SetActive(true);
            levelUpPanel.GetComponent<ActivePanel>().isSetActive = true;
            skill1Button.SetActive(false);
            hpExp.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    private void LevelUp()
    {
        maxHealth += 10; // có thể đặt biến để tùy chỉnh ở ngoài
        healthBar.SetHealth(currentHealth,maxHealth);

        currentLevel++;

        currentExperience = 0;
        experienceBar.SetExperience(currentExperience,currentLevel);
        maxExperience += 100; // có thể đặt biến để tùy chỉnh ở ngoài
        experienceBar.SetMaxExperience(maxExperience);
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
