using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingGameManager : MonoBehaviour
{
    public static RacingGameManager instance;
    public int CurrentCoin;

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

        //DontDestroyOnLoad(gameObject);

    }


    void Update()
    {
        
    }

    public void AddCoin(int amount) 
    {
        CurrentCoin += amount;
    }

    public void SpendCoin(int amount) 
    {
        if (CurrentCoin - amount >= 0)
        {
            CurrentCoin -= amount;
        }
        else 
        {
            Debug.Log("Not Enough Coin!");
        }
    }
}
