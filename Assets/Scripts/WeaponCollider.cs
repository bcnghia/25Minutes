using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public float damage;

    float ratioATK = 0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Khi đối tượng có tag là thằng Enemy và có va chạm với hàng nóng hay không trước khi trừ máu
        if (collision.tag == "Enemy" && !collision.GetComponent<Enemies>().IsBeingAttacked())
        {
            collision.GetComponent<Enemies>().TakeDamage(damage);
        }
    }

    public void SetRatioATK(float ratio)
    {
        ratioATK += ratio;
    }

    public float GetRatioATK() { return ratioATK; }
}