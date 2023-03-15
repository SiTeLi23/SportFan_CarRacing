using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider soundSlider;
    public Slider musicSlider;

    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_SFX = "SFXVolume";

    //button reference
    public GameObject settingUI;
    public GameObject soundButtonOn;
    public GameObject soundButtonOff;
    public GameObject musicButtonOn;
    public GameObject musicButtonOff;
    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        soundSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void SetMusicVolume(float value) 
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value)*20);
        musicButtonOn.SetActive(true);
        musicButtonOff.SetActive(false);
      

    }

    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);  
        soundButtonOn.SetActive(true);
        soundButtonOff.SetActive(false);

    }


    //button function
    public void ClickSoundOn()
    {
        soundButtonOn.SetActive(false);
        soundButtonOff.SetActive(true);
        mixer.SetFloat(MIXER_SFX, -80f);
    }

    public void ClickSoundOff()
    {
        soundButtonOn.SetActive(true);
        soundButtonOff.SetActive(false);
        mixer.SetFloat(MIXER_SFX, 0f);
    }

    public void ClickMusicOn()
    {
        musicButtonOn.SetActive(false);
        musicButtonOff.SetActive(true);
        mixer.SetFloat(MIXER_MUSIC, -80f);
    }

    public void ClickMusicOff()
    {
        musicButtonOn.SetActive(true);
        musicButtonOff.SetActive(false);
        mixer.SetFloat(MIXER_MUSIC, 0f);
    }

    public void CloseSettingUI()
    {
        settingUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenSettingUI()
    {
        settingUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
