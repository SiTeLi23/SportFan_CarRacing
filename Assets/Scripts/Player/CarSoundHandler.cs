using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundHandler : MonoBehaviour
{
    public AudioSource audi;
    public float minPitch = 0.1f;
    private float pitchFromCar;
    void Start()
    {
        
        audi.pitch = minPitch;
    }

    // Update is called once per frame
    void Update()
    {
        
        pitchFromCar = Mathf.Clamp(CarController.instance.theRB.velocity.magnitude/10.0f, 0.1f, 0.7f);
        if (pitchFromCar < minPitch)
        {
             
            pitchFromCar = minPitch;
        }
        else 
        {
            audi.pitch = pitchFromCar;
        }
    }
}
