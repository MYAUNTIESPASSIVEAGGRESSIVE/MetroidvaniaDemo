using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public SceneManagers SceneManagerScript;

    public void PressStart()
    {
        SceneManagerScript.SceneChanger("Level 1");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
