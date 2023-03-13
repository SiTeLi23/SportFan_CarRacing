using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCarButton : MonoBehaviour
{
    public int carIndex;
    public bool locked;
    public GameObject playButton;
    public GameObject unlockButton;

    private void OnEnable()
    {
        playButton.SetActive(false);
        if (locked) 
        {
            unlockButton.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPlayButton() 
    {
        if(locked == false) 
        {
            playButton.SetActive(true);
        }
    }

    public void UnlockCar() 
    {
        locked = false;
        unlockButton.SetActive(false);
    }
}
