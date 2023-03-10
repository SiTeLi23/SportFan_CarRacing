using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && CurrentLevelManager.instance.gameOver == false) 
        {
            gameObject.SetActive(false);
            CurrentLevelManager.instance.ShowNextLevelPanel();
        }
    }
}
