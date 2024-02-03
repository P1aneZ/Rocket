using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //ºÏ≤‚ «∑Ò‘›Õ£
    public static bool GameIsPaused;
    //ªÒ»°‘›Õ£UI
    public GameObject PauseUI;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void Remake()
    {
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
}
