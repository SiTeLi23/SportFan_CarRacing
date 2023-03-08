using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text coinNumText;
    public GameObject coinTextPopOut;

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

   public void UpdateCoinText() 
    {
        coinNumText.text = RacingGameManager.instance.CurrentCoin.ToString();
        
    }

    public void PopOutCoinText(int amount)
    {
       GameObject c= Instantiate(coinTextPopOut,transform.position,Quaternion.identity);
        c.transform.SetParent(transform);
        coinTextPopOut.GetComponent<TextPopOut>().popOutText.text = "Coins+ : " + amount.ToString();
        Destroy(c, 1f);
    }
       
}
