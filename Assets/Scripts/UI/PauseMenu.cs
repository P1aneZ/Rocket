using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //检测是否暂停
    public static bool GameIsPaused;
    //获取暂停UI
    public GameObject PauseUI;
    //获取计分系统
    public PointManager pointManager;

    private void Start()
    {
        pointManager = GameObject.Find("PointsManager")?.GetComponent<PointManager>();
    }

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
        pointManager.time = 0;
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void BackToMenu()
    {
        
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
}
