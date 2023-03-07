using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumObstacle : MonoBehaviour
{
    public float swingAngle = 45.0f;
    public float swingFrequency = 1.0f;

    private float maxAngle;
    private float minAngle;

    private float swing;
    private float angle;

    void Start()
    {
        maxAngle = transform.rotation.eulerAngles.z + swingAngle;
        minAngle = transform.rotation.eulerAngles.z - swingAngle;
    }

    void Update()
    {
        swing = Mathf.Sin(Time.time * swingFrequency) * swingAngle;
        angle = Mathf.Lerp(minAngle, maxAngle, (swingAngle + swing) / (2 * swingAngle));
        transform.rotation = Quaternion.Euler(angle, 0.0f, 0.0f);
    }
}
