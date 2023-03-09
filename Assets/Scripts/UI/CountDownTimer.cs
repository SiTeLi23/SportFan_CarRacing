using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    [Header("Timer")]
    public float countDownTimer = 5f;

    [Header("Things to stop")]
    private Transform player;
    public CarController carController;

    public TMP_Text countDownText;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player.GetComponent<CarController>() != null)
        {
            carController = player.GetComponent<CarController>();
        }
        carController.enabled = false;
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

        carController.enabled = true;
        countDownText.text = "GO!";
        CurrentLevelManager.instance.GameStart();
        yield return new WaitForSeconds(1f);
        
        countDownText.gameObject.SetActive(false);
        
    }

}
