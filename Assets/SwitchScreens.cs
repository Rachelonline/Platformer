using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScreens : MonoBehaviour
{

    public void HomeScreen()
    {
        SceneManager.LoadScene("Home");
    }

    public void LevelsScreen()
    {
        SceneManager.LoadScene("Levels");
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }
}
