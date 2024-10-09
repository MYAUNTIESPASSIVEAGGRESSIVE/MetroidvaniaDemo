using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    [Header("Script References")]
    public PlayerDeath PlayerDeathScript;

    private void OnCollisionEnter2D(Collision2D player)
    {
        // when the player hits the collider then the death function is activated.
        if (player.gameObject.CompareTag("Player"))
        {
            PlayerDeathScript.OnPlayerDeath();
        }
    }
}
