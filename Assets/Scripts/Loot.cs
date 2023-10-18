using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Loot : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;

    public int dropChance;

    // Khi nhặt vật phẩm
    public int healthRestoreAmount = 0;

    public Loot(string lootName, int dropChance, int healthRestoreAmount = 0) 
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
        this.healthRestoreAmount = healthRestoreAmount;

    }
}
