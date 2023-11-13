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

    // Định dạng lại cách sắp xếp của chỉ số Ratio khi in lên Panel
    public static string FormatNumberWithSign(float number)
    {
        return ((number >= 0) ? "+" + number.ToString() : number.ToString()) + "%";
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
        sizeTextPause.text = FormatNumberWithSign(weapon.GetRatioSizeWeapon());
        sizeTextLevelUp.text = FormatNumberWithSign(weapon.GetRatioSizeWeapon());
    }

    public void SetRatioAttackSpeed()
    {
        attackSpeedTextPause.text = FormatNumberWithSign(weapon.GetRatioAttackSpeed());
        attackSpeedTextLevelUp.text = FormatNumberWithSign(weapon.GetRatioAttackSpeed());
    }

    public void SetRatioATK()
    {
        atkTextPause.text = FormatNumberWithSign(weaponCollider.GetRatioATK());
        atkTextLevelUp.text = FormatNumberWithSign(weaponCollider.GetRatioATK());
    }

    public void SetRatioLifeSteal()
    {
        lifeStealTextPause.text = FormatNumberWithSign(weaponCollider.GetRatioLifeSteal());
        lifeStealTextLevelUp.text = FormatNumberWithSign(weaponCollider.GetRatioLifeSteal());
    }

    public void SetRatioSPD()
    {
        spdTextPause.text = FormatNumberWithSign(playerMovement.GetRatioSPD());
        spdTextLevelUp.text = FormatNumberWithSign(playerMovement.GetRatioSPD());
    }
}
