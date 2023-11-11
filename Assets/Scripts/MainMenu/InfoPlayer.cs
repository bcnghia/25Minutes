using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpTextPause, hpTextLevelUp;
    [SerializeField] private TextMeshProUGUI spdTextPause, spdTextLevelUp;

    Player player;
    PlayerMovement playerMovement;
    float curHealth, maxHealth;
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();

        SetHealth();
    }


    void Update()
    {
        SetHealth();
        SetRatioSPD();
    }

    public void SetHealth()
    {
        curHealth = player.GetHealth();
        maxHealth = player.GetMaxHealth();
        hpTextPause.text = curHealth + " / " + maxHealth;
        hpTextLevelUp.text = curHealth + " / " + maxHealth;

    }

    public void SetRatioSPD()
    {
        spdTextPause.text = $"+{playerMovement.GetRatioSPD()}%";
        spdTextLevelUp.text = $"+{playerMovement.GetRatioSPD()}%";
    }
}
