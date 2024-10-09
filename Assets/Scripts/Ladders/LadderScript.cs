using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    [Header("Object References")]
    public PlayerControl PlayerScript;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PlayerScript.OnLadder = true;
            PlayerScript.LadderMovement();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            PlayerScript.OnLadder = false;
        }
    }
}
