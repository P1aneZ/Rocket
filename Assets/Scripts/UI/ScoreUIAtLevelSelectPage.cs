using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIAtLevelSelectPage : MonoBehaviour
{
    public TMP_Text[] score;
    private int[] levelScore;

    public void Awake()
    {
        levelScore = new int[9];
    }

    public void Start()
    {
        // 读取分数
        for(int i = 1; i <= 9; i++)
        {
            levelScore[i-1] = PlayerPrefs.GetInt("Level"+ i +"Score");
        }

        Page1();
    }

    public void Page1()
    {
        //显示分数
        for (int i = 0; i < 6; i++)
        {
            score[i].text = "关卡得分\n" + levelScore[i]; 
        } 
    }

    public void Page2()
    {
        //显示分数
        for (int i = 0; i < 3; i++)
        {
            score[i].text = "关卡得分\n" + levelScore[i+6];
        }
    }
}
