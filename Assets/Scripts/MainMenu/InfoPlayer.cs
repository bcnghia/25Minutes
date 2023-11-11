using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpTextPause, hpTextLevelUp;
    [SerializeField] private TextMeshProUGUI atkTextPause, atkTextLevelUp;
    [SerializeField] private TextMeshProUGUI spdTextPause, spdTextLevelUp;

    Player player;
    PlayerMovement playerMovement;
    WeaponCollider weaponCollider;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerMovement>();
        weaponCollider = GameObject.FindGameObjectWithTag("WeaponCollider").transform.GetComponent<WeaponCollider>();

        SetHealth();
    }


    void Update()
    {
        SetHealth();
        SetRatioSPD();
        SetRatioATK();
    }

    public void SetHealth()
    {
        float curHealth = player.GetHealth();
        float maxHealth = player.GetMaxHealth();
        hpTextPause.text = curHealth + " / " + maxHealth;
        hpTextLevelUp.text = curHealth + " / " + maxHealth;
    }

    public void SetRatioATK()
    {
        atkTextPause.text = $"+{weaponCollider.GetRatioATK()}%";
        atkTextLevelUp.text = $"+{weaponCollider.GetRatioATK()}%";
    }

    public void SetRatioSPD()
    {
        spdTextPause.text = $"+{playerMovement.GetRatioSPD()}%";
        spdTextLevelUp.text = $"+{playerMovement.GetRatioSPD()}%";
    }
}
