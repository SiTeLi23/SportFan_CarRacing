using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopOut : MonoBehaviour
{
    public float speed = 2f;
    public TMP_Text popOutText;



    // Update is called once per frame
    void Update()
    {

       transform.position += new Vector3(0, speed, 0);
        Destroy(gameObject, 1f);
    }

}
