using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public SceneManagers SceneManagerScript;
    public GameObject DeathScreenUI;
    public GameObject Player;
    // change this to match player start pos
    public static Vector2 CurrentCheckPoint;
    public bool PlayerDied = false;

    private void Update()
    {
        if (PlayerDied) OnPlayerDeath();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManagerScript.FadeIn(1);
    }

    private void OnPlayerDeath()
    {
        DeathScreenUI.SetActive(true);
        Player.SetActive(false);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
