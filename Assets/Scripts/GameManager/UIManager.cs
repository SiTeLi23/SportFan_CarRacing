using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text lifeNumText;
    public TMP_Text coinNumText;
    public GameObject coinTextPopOut;
    public GameObject transferLevelHint;
    public GameObject fadeOutScreen;

    //UI Reference
    public GameObject endLevelPanel;
    public GameObject endLevelButton;

    private void Awake()
    {
        #region singleton
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

    private void Start()
    {
        UpdateLifeText();
        UpdateCoinText();
    }

    public void UpdateLifeText() 
    {
        lifeNumText.text = RacingGameManager.instance.ReturnCurrentLives().ToString();
    }

    public void UpdateCoinText() 
    {
        coinNumText.text = RacingGameManager.instance.ReturnTotalCoins().ToString();
        
    }

    public void PopOutCoinText(int amount)
    {
       GameObject c= Instantiate(coinTextPopOut,transform.position,Quaternion.identity);
        c.transform.SetParent(transform);
        coinTextPopOut.GetComponent<TextPopOut>().popOutText.text = "Coins+ " + amount.ToString();
        Destroy(c, 1f);
    }

    public void ShowTransferMessage() 
    {
        if (transferLevelHint)
        {
            transferLevelHint.SetActive(true);
        }
    }

    public void StartFadeOut() 
    {
        fadeOutScreen.SetActive(true);
    }

    public void ShowEndLevelPanel()
    {
        if (endLevelPanel)
        {
            endLevelPanel.SetActive(true);

        }

        if (endLevelButton) 
        {
            if (endLevelButton.activeInHierarchy) 
            {
                endLevelButton.SetActive(false);
            }
        }

        if (CurrentLevelManager.instance.startGame == true)
        {
            CurrentLevelManager.instance.startGame = false;
        }
    }

    public void CloseEndLevelPanel() 
    {
        endLevelPanel.SetActive(false);
        endLevelButton.SetActive(true);
    }


    #region Button Function

    public void RestartGame() 
    {     
        RacingGameManager.instance.SpendLife(1);
        UpdateLifeText();
        RacingGameManager.instance.ClearCurrentEarnedCoins();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ReturnToMainMenu() 
    {
        RacingGameManager.instance.SpendLife(1);
        UpdateLifeText();
        RacingGameManager.instance.ClearCurrentEarnedCoins();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNextLevel(string nextLevelToLoad)
    {
        Time.timeScale = 1;
        RacingGameManager.instance.ClearCurrentEarnedCoins();
        SceneManager.LoadScene(nextLevelToLoad);
    }



    #endregion

}
