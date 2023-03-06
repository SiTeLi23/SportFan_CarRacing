using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    public float countDownTimer = 5f;

    [Header("Things to stop")]
    public PlayerCarController playerCarController;

    public TMP_Text countDownText;

    void Start()
    {
        playerCarController.enabled = false;
        StartCoroutine(UpdateTimer());
    }

    void Update()
    {
        
    }

    IEnumerator UpdateTimer() 
    {
       while(countDownTimer > 0) 
        {
            countDownText.text = countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }

        playerCarController.enabled = true;
        countDownText.text = "Start!";
        yield return new WaitForSeconds(1f);
        countDownText.gameObject.SetActive(false);
    }

}
