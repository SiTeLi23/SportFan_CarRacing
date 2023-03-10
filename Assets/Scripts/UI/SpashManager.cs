using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpashManager : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(LoadMainMenu());
    }

    public IEnumerator LoadMainMenu() 
    {
        yield return new WaitForSeconds(2.2f);

        SceneManager.LoadScene("MainMenu");
    
    }
}
