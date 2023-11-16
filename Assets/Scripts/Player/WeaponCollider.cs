using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public float damage;

    float ratioATK = 0f;
    float ratioLifeSteal = 0f;

    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Khi đối tượng có tag là thằng Enemy và có va chạm với hàng nóng hay không trước khi trừ máu
        if (collision.tag == "Enemy" && !collision.GetComponent<Enemies>().IsBeingAttacked())
        {
            // Gây damage cho quái
            collision.GetComponent<Enemies>().TakeDamage(damage);

            // Nếu có tỉ lệ hút máu thì mới hút máu cho người chơi
            if (ratioLifeSteal != 0)
            {
                // Lượng máu hút được dựa trên tỉ lệ sát thương
                float hpDamage = damage * ratioLifeSteal / 100;
                // Lượng máu hút được dựa trên tỉ lệ máu của mục tiêu

                // CÂN BẰNG GAME -> Ưu tiên chọn lượng máu hút được thấp hơn nhằm tránh người chơi quá mạnh
                player.LifeSteal(hpDamage);
            }
        }
    }

    public void SetRatioATK(float ratio)
    {
        ratioATK += ratio;
    }

    public void SetRatioLifeSteal(float ratio)
    {
        ratioLifeSteal += ratio;
    }

    public float GetRatioATK() { return ratioATK; }
    public float GetRatioLifeSteal() { return ratioLifeSteal; }
}