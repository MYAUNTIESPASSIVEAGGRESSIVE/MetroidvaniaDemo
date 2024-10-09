using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [Header("UI Attributes")]
    public float temp;

    [Header("ObjectReferences")]
    public GameObject Player;

    // DeathScreenUI opens up and the player is able to select the options.
    public void OnPlayerDeath()
    {
        Player.SetActive(false);
    }

}
