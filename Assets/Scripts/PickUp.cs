using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float experience;
    Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.IncreaseExp(experience);
            Debug.Log("Collected Item");
            CollectLoot();
        }
    }
    public void CollectLoot()
    {
        //if (gameObject.tag == "Healing")
        //{
        //    GetComponent<Player>().Healing();
        //    //HealingHP();
        //    Debug.Log("Healing");
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

