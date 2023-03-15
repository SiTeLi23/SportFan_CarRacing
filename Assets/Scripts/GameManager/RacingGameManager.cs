using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingGameManager : MonoBehaviour
{
    public static RacingGameManager instance;
    [Header("Lives")]
    [SerializeField] private int maxLives = 5;
    [SerializeField] private int currentLives;
    [SerializeField] private int totalScore;

    [Header("Coins")]
    [SerializeField] private int totalCoins;
    [SerializeField] private int currentEarnedCoins;


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

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        currentLives = maxLives;
    }


    #region Lives Logic Handling

    public void RecoverLife(int amount) 
    {
        currentLives += amount;
        if(currentLives>= maxLives) 
        {
            currentLives = maxLives;
        }
    }

    public void SpendLife(int amount) 
    {
        currentLives -= amount;
        if (currentLives <= 0) 
        {
            currentLives = 0;
        }
    }



    #endregion


    #region Coins Logic Handleing
    public void AddCoin(int amount) 
    {
        totalCoins += amount;
    }

    public void SpendCoin(int amount) 
    {
        if (totalCoins - amount >= 0)
        {
            totalCoins -= amount;
        }
        else 
        {
            Debug.Log("Not Enough Coin!");
        }
    }
    

    public void CalculateCurrentEarnedCoins(int amount) 
    {
        currentEarnedCoins += amount;
    }

    public void ClearCurrentEarnedCoins() 
    {
        currentEarnedCoins = 0;
    }

    #endregion


    #region Handling Score Logic;
    public void AddToTotalScore(int amount) 
    {
        totalScore += amount;
    }

    public void ClearTotalScore() 
    {
        totalScore = 0;
    }

    #endregion


    //getter
    public int ReturnTotalCoins() 
    {
        return totalCoins;
    }

    public int ReturnCurrentEarnedCoins() 
    {
        return currentEarnedCoins;
    }

    public int ReturnMaxLives() 
    {
        return maxLives;
    }

    public int ReturnCurrentLives() 
    {
        return currentLives;
    }

    public int ReturnTotalScore() 
    {
        return totalScore;
    }
}
