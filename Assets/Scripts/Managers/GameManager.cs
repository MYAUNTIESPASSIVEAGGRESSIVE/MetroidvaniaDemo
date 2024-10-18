using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PlayerControl PlayerScript;
    public SceneManagers SceneManagerScript;
    // change this to match player start pos
    public static Vector2 CurrentCheckPoint;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void OnPlayerDeath()
    {
        Time.timeScale = 0;
        PlayerScript.OnDeath();
    }

    public void LoadNextScene(string sceneName)
    {
        SceneManagerScript.SceneChanger(sceneName);
    }

}
