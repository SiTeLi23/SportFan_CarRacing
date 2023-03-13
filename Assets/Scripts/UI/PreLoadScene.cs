using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoadScene : MonoBehaviour
{
    public string sceneToPreload;

    void Start()
    {
        // Load the scene asynchronously in the background
        SceneManager.LoadSceneAsync(sceneToPreload, LoadSceneMode.Additive);
       
    }


}
