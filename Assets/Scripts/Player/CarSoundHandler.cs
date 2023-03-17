using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarSoundHandler : MonoBehaviour {
    public AudioSource engineAudio;
    public float minPitch = 0.3f, maxPitch = 1.5f, pitchOffset = 29f;
    private float pitchFromCar;

    // Mixer Ref
    public AudioMixer EngineSoundMixer;

    void Start()
    {
        
        EngineSoundMixer.SetFloat("Pitch", minPitch);
    }

    // Update is called once per frame
    void Update()
    {
        pitchFromCar = Mathf.Clamp(CarController.instance.theRB.velocity.magnitude/pitchOffset, minPitch, maxPitch);
        if (pitchFromCar < minPitch)
        {
             
            pitchFromCar = minPitch;
        }
        else 
        {
            EngineSoundMixer.SetFloat("Pitch", pitchFromCar);
        }
    }
}
