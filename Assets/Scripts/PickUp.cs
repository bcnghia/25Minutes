using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected Item");
            CollectLoot();
        }
    }
    public void CollectLoot()
    {
        // Xử lý khi vật phẩm được nhặt
        // Tăng kinh nghiệm, hồi máu, tăng tốc, buff, etc,....
        Destroy(gameObject); 
    }
}
