using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpTextPause, hpTextLevelUp;
    [SerializeField] private TextMeshProUGUI sizeTextPause, sizeTextLevelUp;
    [SerializeField] private TextMeshProUGUI attackSpeedTextPause, attackSpeedTextLevelUp;
    [SerializeField] private TextMeshProUGUI atkTextPause, atkTextLevelUp;
    [SerializeField] private TextMeshProUGUI lifeStealTextPause, lifeStealTextLevelUp;
    [SerializeField] private TextMeshProUGUI spdTextPause, spdTextLevelUp;

    Player player;
    PlayerMovement playerMovement;
    Weapon weapon;
    WeaponCollider weaponCollider;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerMovement>();
        weapon = GameObject.FindGameObjectWithTag("Weapon").transform.GetComponent<Weapon>();
        weaponCollider = GameObject.FindGameObjectWithTag("WeaponCollider").transform.GetComponent<WeaponCollider>();

        SetHealth();
    }


    void Update()
    {
        SetHealth();
        SetRatioSizeWeapon();
        SetRatioAttackSpeed();
        SetRatioATK();
        SetRatioLifeSteal();
        SetRatioSPD();
    }

    public void SetHealth()
    {
        float curHealth = player.GetHealth();
        float maxHealth = player.GetMaxHealth();
        hpTextPause.text = curHealth + " / " + maxHealth;
        hpTextLevelUp.text = curHealth + " / " + maxHealth;
    }

    public void SetRatioSizeWeapon()
    {
        sizeTextPause.text = $"+{weapon.GetRatioSizeWeapon()}%";
        sizeTextLevelUp.text = $"+{weapon.GetRatioSizeWeapon()}%";
    }

    public void SetRatioAttackSpeed()
    {
        attackSpeedTextPause.text = $"+{weapon.GetRatioAttackSpeed()}%";
        attackSpeedTextLevelUp.text = $"+{weapon.GetRatioAttackSpeed()}%";
    }

    public void SetRatioATK()
    {
        atkTextPause.text = $"+{weaponCollider.GetRatioATK()}%";
        atkTextLevelUp.text = $"+{weaponCollider.GetRatioATK()}%";
    }

    public void SetRatioLifeSteal()
    {

    }

    public void SetRatioSPD()
    {
        spdTextPause.text = $"+{playerMovement.GetRatioSPD()}%";
        spdTextLevelUp.text = $"+{playerMovement.GetRatioSPD()}%";
    }
}
