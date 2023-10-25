using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;

    public HealthBar healthBar;

    public bool isAttacking; // Tạo biến để xác định trạng thái tấn công

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
    public void RestoreHealth(int amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
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


    //public void IncreaseHealth(int amount)
    //{
    //    currentHealth += amount;

    //    if (currentHealth > maxHealth)
    //    {
    //        currentHealth = maxHealth;
    //    }

    //    healthBar.SetHealth(currentHealth);
    //}

}
