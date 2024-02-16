using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conclusion : MonoBehaviour
{
    //��ȡ��ֵ
    public PointManager pointManager;

    //��ȡ�ı�
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

    public int levelnum = SceneLoadManager.levelNum;

    private void Start()
    {
        pointManager = GameObject.Find("PointsManager").GetComponent<PointManager>();

        switch (levelnum)
        {
            case 1:
                bestTime = 10;
                worstTime = 30;
                break;
            default:
                break;
        }

        ConclusionUI();
    }

    private void ConclusionUI()
    {
        PointsChange();

        timeUI.text = "ͨ��ʱ�䣺" + time.ToString();
        timePointUI.text = "+" + timePoint.ToString();

        lifeUI.text = "ʣ��Ѫ����" + life.ToString();
        lifePointUI.text="+"+lifePoint.ToString();

        scoreUI.text= "�ؿ��ܷ֣�"+score.ToString();
    }

    private void PointsChange()
    {
        time = pointManager.time;
        if (time <= bestTime)
        {
            timePoint = 1000;
        }
        else if (time > bestTime && time <= worstTime)
        {
            timePoint = 1000 - (int)(time - bestTime / worstTime - bestTime) * 900;
        }
        else if (time >= worstTime)
        {
            timePoint = 100;
        }
        pointManager.time = 0;

        life = pointManager.health;
        maxLife = pointManager.maxHealth;
        lifePoint = 10 + (int)(life / maxLife * 1990);

        score = lifePoint + timePoint;
    }
}
