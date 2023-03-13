using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class CurrentLevelManager : MonoBehaviour
{

    public static CurrentLevelManager instance;

    public bool startGame;
    public bool gameOver;

    public Transform lookPoint;
    public CinemachineVirtualCamera cm;

    [Header("UI Reference")]
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;

    [Header("Text Display")]
    public TMP_Text earnedCoinNum;
    
    

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

        lookPoint = GameObject.FindGameObjectWithTag("LookPoint").transform;
        cm.LookAt = lookPoint;
        cm.Follow = lookPoint;
    }


    public float levelTime;
    public TMP_Text levelTimerText;

    private void Start()
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(false);
        }

        if (nextLevelPanel) 
        {
            nextLevelPanel.SetActive(false);
        }
    }

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
                ShowGameOverPanel();
            }
        }
        
    }


    public void UpdateLevelTimeUI() 
    {
        int currentTime = Mathf.CeilToInt(levelTime);
        levelTimerText.text = currentTime.ToString();
    
    }


    public void ShowNextLevelPanel() 
    {
        if (nextLevelPanel) 
        {
            nextLevelPanel.SetActive(true);

         if (earnedCoinNum)
         {
             earnedCoinNum.text = "+" + RacingGameManager.instance.ReturnCurrentEarnedCoins().ToString();
         }

           Time.timeScale = 0;
        }

        SoundManager.instance.engineIdle.gameObject.SetActive(false);

    }

    public void GameStart() 
    {
        startGame = true;

    }

    public void ShowGameOverPanel() 
    {
        gameOver = true;
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }



        SoundManager.instance.engineIdle.gameObject.SetActive(false);



    }
}
