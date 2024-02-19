using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conclusion : MonoBehaviour
{
    //获取数值
    public PointManager pointManager;

    //获取文本
    public TMP_Text timeUI;
    public TMP_Text timePointUI;
    public TMP_Text lifeUI;
    public TMP_Text lifePointUI;
    public TMP_Text scoreUI;

    public float time;
    public int timePoint;
    public float life;
    public float maxLife;
    public int lifePoint;
    public int score;

    public float bestTime;
    public float worstTime;

    public int levelnum;

    private void Start()
    {
        levelnum = SceneLoadManager.levelNum;

        pointManager = GameObject.Find("PointsManager")?.GetComponent<PointManager>();

        switch (levelnum)
        {
            case 1:
                bestTime = 10;
                worstTime = 20;
                break;
            case 2:
                bestTime = 20;
                worstTime = 60;
                break;
            case 3:
                bestTime = 15;
                worstTime = 35;
                break;
            case 4:
                bestTime = 35;
                worstTime = 80;
                break;
            case 5:
                bestTime = 15;
                worstTime = 40;
                break;
            case 6:
                bestTime = 28;
                worstTime = 100;
                break;
            case 7:
                bestTime = 38;
                worstTime = 70;
                break;
            case 8:
                bestTime = 42;
                worstTime = 110;
                break;
            case 9:
                bestTime = 60;
                worstTime = 130;
                break;
            default:
                break;
        }

        ConclusionUI();
    }

    private void ConclusionUI()
    {
        PointsChange();

        timeUI.text = "通关时间：" + time.ToString();
        timePointUI.text = "+" + timePoint.ToString();

        lifeUI.text = "剩余血量：" + life.ToString();
        lifePointUI.text="+"+lifePoint.ToString();

        scoreUI.text= "关卡总分："+score.ToString();
    }

    private void PointsChange()
    {
        if(pointManager)
            time = pointManager.time;
        if (time <= bestTime)
        {
            timePoint = 1000;
        }
        else if (time > bestTime && time <= worstTime)
        {
            timePoint = 1000 - (int)(((time - bestTime) / (worstTime - bestTime)) * 900);
        }
        else if (time >= worstTime)
        {
            timePoint = 100;
        }

        if(pointManager)
        {
            pointManager.time = 0;
            life = pointManager.health;
            maxLife = pointManager.maxHealth;
        }
            
        lifePoint = (int)(life / maxLife * 2000);

        score = lifePoint + timePoint;

        // 存储分数
        int highestScore = PlayerPrefs.GetInt("Level" + levelnum + "Score");
        if ( score > highestScore )
        {
            PlayerPrefs.SetInt("Level"+ levelnum +"Score", score);
        }

    }
}
