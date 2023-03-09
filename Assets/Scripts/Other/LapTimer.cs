using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTimer : MonoBehaviour
{
    public float lapTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lapTime = Time.deltaTime;
        
    }
}
