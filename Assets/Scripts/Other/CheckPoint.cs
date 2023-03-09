using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject nextCheckPoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player")) 
        {
            gameObject.SetActive(false);
            if (nextCheckPoint != null)
            {
                nextCheckPoint.SetActive(true);
            }

        }
    }
}
