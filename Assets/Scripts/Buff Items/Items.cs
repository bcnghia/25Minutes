using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private string titleItem;
    [SerializeField, TextArea(3,10)] private string descriptionItem;
    private float levelItem = 0;

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
}
