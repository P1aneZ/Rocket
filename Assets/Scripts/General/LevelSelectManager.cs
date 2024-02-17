using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    //掌管按钮的父物体
    public GameObject levelSelect;
    //每个按钮的数组
    Button[] levelSelectButtons;
    //解锁的关卡数
    int unlockedLevelIndex;

    private void Start()
    {
        //读取解锁的关卡数
        unlockedLevelIndex = PlayerPrefs.GetInt("unlockedLevel");
        //父物体下有几个关卡，就开多大的数组捏
        levelSelectButtons = new Button[levelSelect.transform.childCount];
        //把父物体下的关卡按钮都赋值到数组里捏
        for(int i = 0; i < levelSelect.transform.childCount ; i++)
        {
            levelSelectButtons[i] = levelSelect.transform.GetChild(i).GetComponent<Button>();
            //Debug.Log(i);
        }

        //遍历各个关卡按钮，都设置为不可交互
        for (int i = 0;i < levelSelectButtons.Length ; i++)
        {
            levelSelectButtons[i].interactable = false;
        }

        //遍历已解锁关卡按钮，设置为可交互
        for (int i = 0; i < unlockedLevelIndex + 1 ; i++)
        {
            levelSelectButtons[i].interactable = true;
        }
    }

}
