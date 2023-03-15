using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CurrentLevelManager : MonoBehaviour
{

    public static CurrentLevelManager instance;

    public bool isEndLevel;
    public bool startGame;
    public bool gameOver;
    [SerializeField] private int score;

    public Transform lookPoint;
    public CinemachineVirtualCamera cm;
    public string nextLevelToLoad;

    [Header("UI Reference")]
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;


    [Header("Text Display")]
    public TMP_Text earnedCoinNum;

    [Header("Shader")]
    public GameObject topShader;
    public GameObject fullShader;

    
    

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

    //calculate current level's score
    public int ReturnScore() 
    {
        score = Mathf.CeilToInt(levelTime) * 100 + RacingGameManager.instance.ReturnCurrentEarnedCoins();
        RacingGameManager.instance.AddToTotalScore(score);
        return score;
    }

    public void IncreaseScore(int amount) 
    {
        score += amount;
    }

    public void DescreasScore(int amount) 
    {
        score -= amount;
        if(score <= 0) 
        {
            score = 0;
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

            UIManager.instance.UpdateScoreUI();
           //Time.timeScale = 0;
        }
        if (topShader)
        {
            topShader.SetActive(false);
        }
        if (fullShader)
        {
            fullShader.SetActive(true);
        }


        startGame = false;
        UIManager.instance.ShowTransferMessage();

        if (nextLevelToLoad != null)
        {
            StartCoroutine(LoadNextLevel());
        }

        //SoundManager.instance.engineIdle.gameObject.SetActive(false);

    }


    IEnumerator LoadNextLevel() 
    {

        yield return new WaitForSeconds(5f);
        UIManager.instance.StartFadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nextLevelToLoad);
    }


    public void GameStart() 
    {
        startGame = true;

    }

    public void ShowGameOverPanel() 
    {
        gameOver = true;
        UIManager.instance.UpdateScoreUI();
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        SoundManager.instance.engineIdle.gameObject.SetActive(false);

    }


}
