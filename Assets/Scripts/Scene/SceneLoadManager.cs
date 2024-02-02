using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void ToLevelSelect()
    {
        SceneManager.LoadScene("levelSelect");
    }

    public void ToSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ToLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
}
