using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpTextPause, hpTextLevelUp;

    Player player;
    float curHealth, maxHealth;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();

        SetHealth();
    }


    void Update()
    {
        SetHealth();
    }

    public void SetHealth()
    {
        curHealth = player.GetHealth();
        maxHealth = player.GetMaxHealth();
        hpTextPause.text = curHealth + " / " + maxHealth;
        hpTextLevelUp.text = curHealth + " / " + maxHealth;

    }
}
