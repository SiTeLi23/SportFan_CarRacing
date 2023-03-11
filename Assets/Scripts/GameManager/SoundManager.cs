using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [Header("Audio Source")]
    public AudioSource engineIdle;
    public AudioSource coinCollect;
    public AudioSource buttonClick;


    private void Awake()
    {
        #region Singleton
        if (instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);

        }
        #endregion
    }


    public void PlaySound(AudioSource audio) 
    {

        audio.Play();
    }

    public void StopPlay(AudioSource audio) 
    {
        audio.Stop();
    }

    public void PlayButtonClick() 
    {
        buttonClick.Play();
    }
}
