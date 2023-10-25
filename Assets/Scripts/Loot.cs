using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public string lootName;
    public int dropChance;
    public GameObject lootPrefab; // Thêm trường kiểu GameObject để lưu prefab

    public Loot(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
