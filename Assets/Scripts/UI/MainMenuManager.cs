using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject mainMenuUI;    
    public GameObject profileUI;
    public GameObject settingUI;
    void Start()
    {
        mainMenuUI.SetActive(true);
        profileUI.SetActive(false);
        settingUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLevel(string levelName) 
    {

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
}
