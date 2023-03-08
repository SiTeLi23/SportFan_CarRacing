using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public int rewardAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") 
        {
            Debug.Log("coin added");
            Destroy(gameObject);
            RacingGameManager.instance.AddCoin(rewardAmount);
            UIManager.instance.UpdateCoinText();
            UIManager.instance.PopOutCoinText(rewardAmount);
        }
    }
}
