using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Loot"))
        {
            PickUp lootItem = other.GetComponent<PickUp>();
            if (lootItem != null)
            {
                lootItem.CollectLoot(this.GetComponent<Player>());
            }
        }
    }
}
