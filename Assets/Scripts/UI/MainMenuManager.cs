using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject mainMenuUI;    
    public GameObject profileUI;
    public GameObject settingUI;
    public GameObject tipsUI;
    public GameObject loadingUI;

    [Header("Text Reference")]
    public TMP_Text profileLivesText;
    public TMP_Text profileCoinsText;
    void Start()
    {
        CloseCurrentUI();
        UpdateProfileCoins();
        UpdateProfileLives();
    }



    public void PlayLevel(string levelName) 
    {
        StartCoroutine(LoadLevel(levelName));
        
    }

    public IEnumerator LoadLevel(string levelName) 
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(levelName);

    }

    public void CloseCurrentUI() 
    {
        if (mainMenuUI) 
        {
            mainMenuUI.SetActive(true);
        }

        if (profileUI)
        {
            profileUI.SetActive(false);
        }

        if (settingUI)
        {
            settingUI.SetActive(false);
        }

        if (tipsUI)
        {
            tipsUI.SetActive(false);
        }

        if (loadingUI) 
        {
            loadingUI.SetActive(false);
        }
    }

    public void OpenProfileUI()
    {
        if (mainMenuUI)
        {
            mainMenuUI.SetActive(false);
        }

        if (profileUI)
        {
            profileUI.SetActive(true);
        }
    }

    public void OpenSettingUI()
    {
        if (mainMenuUI)
        {
            mainMenuUI.SetActive(false);
        }

        if (settingUI)
        {
            settingUI.SetActive(true);
        }
    }

    public void OpenTipsUI()
    {
        if (mainMenuUI)
        {
            mainMenuUI.SetActive(false);
        }

        if (tipsUI)
        {
            tipsUI.SetActive(true);
        }
    }

    public void OpenLoadingUI()
    {
        if (mainMenuUI)
        {
            mainMenuUI.SetActive(false);
        }

        if (loadingUI)
        {
            loadingUI.SetActive(true);
        }
    }


    public void UpdateProfileLives() 
    {
        profileLivesText.text = RacingGameManager.instance.ReturnCurrentLives().ToString();
    }

    public void UpdateProfileCoins() 
    {
        profileCoinsText.text = RacingGameManager.instance.ReturnTotalCoins().ToString();
    }
}
