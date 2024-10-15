using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject VCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player") && !other.isTrigger)
       {
            VCam.SetActive(true);
       }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            VCam.SetActive(false);
        }
    }
}
