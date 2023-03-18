using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarSoundHandler : MonoBehaviour {
    public AudioSource engineAudio;
    public AudioSource gearChange;
    public float minPitch = 0.3f, maxPitch = 1.5f, pitchOffset = 29f;
    public float pitchFromCar; // Range 0.3 (Idle) to 1.6 (Full)
    public int gear = 0;
    public AudioClip[] CarAudio;

    // Mixer Ref
    public AudioMixer EngineSoundMixer;

    // Update is called once per frame
    void Update() {
        pitchFromCar = Mathf.Clamp(CarController.instance.theRB.velocity.magnitude/pitchOffset, minPitch, maxPitch);
        if (pitchFromCar < minPitch) {
             pitchFromCar = minPitch;
             engineAudio.pitch = 1f;
        }
        else {
            if (pitchFromCar > 0.3f && gear == 0) {
                gear = 1;
                gearChange.Play();
             }
             if (pitchFromCar > 1.0f && gear == 1) {
                gear = 2;
                gearChange.Play();
             }
             if (pitchFromCar > 1.5f && gear == 2) {
                gear = 3;
                gearChange.Play();
             } 
             if (pitchFromCar <= 0.3f && gear > 0) {
                gear = 0;
                gearChange.Play();
             }
             engineAudio.pitch = pitchFromCar == 0.3f ? 1 : pitchFromCar * gear / 4;
        }
        
        
    }
}
