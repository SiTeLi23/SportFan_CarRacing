using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBox : MonoBehaviour
{
    public float speed = 3f;
    public float amplitude = 2f;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float z = Mathf.Sin(Time.time * speed) * amplitude; 
        transform.position = startPosition + new Vector3(0f, 0.0f, z);
    }
}
