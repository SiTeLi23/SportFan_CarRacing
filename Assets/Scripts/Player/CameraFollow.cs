using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform lookPoint;
    public float speed;
    private void Awake()
    {
        lookPoint = GameObject.FindGameObjectWithTag("LookPoint").transform;
    }

    private void FixedUpdate()
    {
        Follow();
    }

    public void Follow() 
    {
        transform.position = Vector3.Lerp(transform.position, lookPoint.position, speed * Time.deltaTime);
        transform.LookAt(lookPoint);
        
    }
}
