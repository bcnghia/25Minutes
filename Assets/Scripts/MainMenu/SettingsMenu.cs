using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;

    public void ToggleMusic()
    {
        SoundManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        SoundManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        SoundManager.Instance.SFXVolume(sfxSlider.value);
    }
}
