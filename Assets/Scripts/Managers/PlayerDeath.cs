using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [Header("UI Attributes")]
    public float temp;

    [Header("Object References")]
    public GameObject Player;

    [Header("Death Variables")]
    public static bool PlayerDead;
    // DeathScreenUI opens up and the player is able to select the options.
    public void OnPlayerDeath()
    {
        Player.SetActive(false);
    }

    private void Update()
    {
        if (PlayerDead)
        {
            // UI activates
        }
    }
}
