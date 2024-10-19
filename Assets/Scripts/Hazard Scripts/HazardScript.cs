using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    [Header("Script References")]
    public GameManager GameManagerScript;


    private void OnTriggerEnter2D(Collider2D player)
    {
        // when the player hits the collider then the death function is activated.
        if (player.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            GameManagerScript.PlayerDied = true;
        }
    }
}
