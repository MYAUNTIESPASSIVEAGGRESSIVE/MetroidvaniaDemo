using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PlayerDeath PlayerDeathScript;
    // change this to match player start pos
    public static Vector2 CurrentCheckPoint;

    private void Awake()
    {
        PlayerDeath.PlayerDead = true;
        GameObject.FindGameObjectWithTag("Player").transform.position = CurrentCheckPoint;
    }
}
