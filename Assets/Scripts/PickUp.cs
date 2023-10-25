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
            CollectLoot(other.GetComponent<Player>());
        }
    }
    public void CollectLoot(Player player)
    {
        //Loot lootToCollect = FindLootByLootName("Chicken");
        //Loot lootToCollect2 = FindLootByLootName("Cake");
        //Loot lootToCollect3 = FindLootByLootName("Hamburger");

        //if (lootToCollect != null)
        //{
        //    if (lootToCollect.lootName == "Chicken" && player != null)
        //    {
        //        // Hồi máu cho người chơi bằng cách gọi phương thức RestoreHealth

        //    }
        //}

        //if (lootToCollect2 != null)
        //{
        //    if (lootToCollect2.lootName == "Cake" && player != null)
        //    {

        //    }
        //}

        //if (lootToCollect3 != null)
        //{
        //    if (lootToCollect3.lootName == "Hamburger" && player != null)
        //    {

        //    }
        //}

        
        


        // Hủy đối tượng khi nhặt vật phẩm
        Destroy(gameObject);
    }

    private Loot FindLootByLootName(string name)
    {
        // Tìm Loot dựa trên "name" trên tất cả đối tượng Loot có trong trò chơi.

        Loot[] allLoot = FindObjectsOfType<Loot>(); // Tìm tất cả đối tượng Loot trong trò chơi.

        foreach (var lootObject in allLoot)
        {
            if (lootObject.lootName == name)
            {
                return lootObject;
            }
        }
        return null;
    }
}

