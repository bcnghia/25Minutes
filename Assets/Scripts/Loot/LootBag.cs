using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public List<Loot> lootList = new List<Loot>();

    Loot GetLoot()
    {
        int randomNumber = Random.Range(1, 101); //1 - 100%
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            Loot dropItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return dropItem;
        }
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot dropItem = GetLoot();
        if (dropItem != null && dropItem.lootPrefab != null)
        {
            GameObject lootGameObject = Instantiate(dropItem.lootPrefab, spawnPosition, Quaternion.identity);

            float dropForce = 20f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
    }
}
