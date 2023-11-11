using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private string titleItem;
    [SerializeField, TextArea(3,10)] private string descriptionItem;
    private float levelItem = 0;

    [SerializeField] private float ratioSPD = 0;

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

    public float GetRatioSPD() { return ratioSPD; }

    public void IncreaseIndex()
    {
        if (ratioSPD > 0)
        {
            PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerMovement>();
            //float moveSpeed = playerMovement.moveSpeed;

            playerMovement.SetRatioSPD(ratioSPD);
            playerMovement.moveSpeed += playerMovement.moveSpeed * ratioSPD / 100;
            Debug.Log(playerMovement.moveSpeed + " Move Speed");
            Debug.Log(ratioSPD + " ratio");
        }
    }
}
