using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentLevelManager : MonoBehaviour
{

    public static CurrentLevelManager instance;
    public bool startGame;
    

    private void Awake()
    {
        #region SingleTon
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


    public float levelTime;
    public TMP_Text levelTimerText;



    // Update is called once per frame
    void Update()
    {
        if (startGame) 
        {
            levelTime -= Time.deltaTime;
            UpdateLevelTimeUI();
            if(levelTime <= 0) 
            {
                levelTime = 0;
                UpdateLevelTimeUI();
                startGame = false;
            }
        }
        
    }


    public void UpdateLevelTimeUI() 
    {
        int currentTime = (int)levelTime;
        levelTimerText.text = currentTime.ToString();
    
    }

    public void GameStart() 
    {
        startGame = true;
    }
}
