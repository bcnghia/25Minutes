using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private string titleItem;
    [SerializeField, TextArea(3,10)] private string descriptionItem;
    private float levelItem = 0;

    [SerializeField] private float ratioSPD = 0;
    [SerializeField] private float ratioATK = 0;
    [SerializeField] private float ratioAttackSpeed = 0;
    [SerializeField] private float ratioSizeWeapon = 0;
    [SerializeField] private float ratioLifeSteal = 0;

    public string GetTitleItem()
    {
        return titleItem;
    }

    public string GetDescriptionItem()
    {
        return descriptionItem;
    }

    public float GetLevelItem()
    {
        return levelItem;
    }

    public void SetLevelItem(float level)
    {
        levelItem = level;
    }

    public void IncreaseIndex()
    {
        if (ratioSPD != 0)
        {
            PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerMovement>();

            playerMovement.SetRatioSPD(ratioSPD);
            playerMovement.moveSpeed += playerMovement.moveSpeed * ratioSPD / 100;
        }

        if (ratioATK != 0)
        {
            WeaponCollider weaponCollider = GameObject.FindGameObjectWithTag("WeaponCollider").transform.GetComponent<WeaponCollider>();

            weaponCollider.SetRatioATK(ratioATK);
            weaponCollider.damage += weaponCollider.damage * ratioATK / 100;
        }

        if (ratioAttackSpeed != 0)
        {
            Weapon weapon = GameObject.FindGameObjectWithTag("Weapon").transform.GetComponent<Weapon>();

            weapon.SetRatioAttackSpeed(ratioAttackSpeed);
            weapon.attackSpeed += weapon.attackSpeed * ratioAttackSpeed / 100;
        }

        if (ratioSizeWeapon != 0)
        {
            Weapon weapon = GameObject.FindGameObjectWithTag("Weapon").transform.GetComponent<Weapon>();

            weapon.SetRatioSizeWeapon(ratioSizeWeapon);
            weapon.sizeWeapon += weapon.sizeWeapon * ratioSizeWeapon / 100;
        }

        if (ratioLifeSteal != 0)
        {
            WeaponCollider weaponCollider = GameObject.FindGameObjectWithTag("WeaponCollider").transform.GetComponent<WeaponCollider>();

            weaponCollider.SetRatioLifeSteal(ratioLifeSteal);
        }
    }
}
