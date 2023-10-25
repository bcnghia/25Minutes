using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public string lootName;
    public int dropChance;
    public int healthRestoreAmount = 0;
    public GameObject lootPrefab; // Thêm trường kiểu GameObject để lưu prefab

    public Loot(string lootName, int dropChance, int healthRestoreAmount = 0)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
        this.healthRestoreAmount = healthRestoreAmount;
    }
}
