using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Text txtButton;
    [SerializeField] private string normalColorButton;
    [SerializeField] private float scaleAmount = 1.2f;
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private float defaultVolume;

    AudioSource audioSource;

    Vector2 sizeTemp;

    Color txtColorTemp;
    void Start()
    {
        sizeTemp = gameObject.GetComponent<RectTransform>().sizeDelta;
        txtColorTemp = txtButton.color;

        audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.clip = hoverSound;
        audioSource.volume = defaultVolume;
    }
    void PlayHoverSound()
    {
        audioSource.clip = hoverSound;
        if(hoverSound != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }

    private void ResetButton()
    {
        txtButton.color = txtColorTemp;

        // Thu nhỏ kích thước Button về như cũ
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = sizeTemp;
    }

    // Biến đổi Button khi hold chuột vào Button (Enter)
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Bật sound effect
        PlayHoverSound();

        // Đổi màu text 
        ColorUtility.TryParseHtmlString(normalColorButton, out Color color);
        txtButton.color = color;

        // Phóng đại kích thước Button
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = sizeTemp * scaleAmount;
    }

    // Biến đổi Button khi hold chuột vào Button (Exit)
    public void OnPointerExit(PointerEventData eventData)
    {
        ResetButton();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(null);

        ResetButton();
    }
}
