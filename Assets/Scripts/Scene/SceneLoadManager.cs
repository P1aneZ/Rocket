using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.tvOS;

public class SceneLoadManager : MonoBehaviour
{
    //当前所在的关卡数
    [SerializeField]public static int levelNum;

    [Header("事件监听")]
    //监听点击“下一关卡”事件
    public VoidEventSO nextLevel;
    //监听点击“重新开始”事件
    public VoidEventSO remake;

    public void Start()
    {
        
    }

    public void OnEnable()
    {
        nextLevel.OnEventRaised += ToNextLevel;
        remake.OnEventRaised += Remake;
    }

    public void OnDisable()
    {
        nextLevel.OnEventRaised -= ToNextLevel;
        remake.OnEventRaised -= Remake;
    }

    public void ToLevelSelectPage1()
    {
        SceneManager.LoadScene("levelSelectPage1");
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
        levelNum = 1;
        SceneManager.LoadScene("Level1");
    }

    public void ToLevel2()
    {
        levelNum = 2;
        SceneManager.LoadScene("Level2");
    }

    public void ToLevel3()
    {
        levelNum = 3;
        SceneManager.LoadScene("Level3");
    }

    public void ToLevel4()
    {
        levelNum = 4;
        SceneManager.LoadScene("Level4");
    }

    public void ToLevel5()
    {
        levelNum = 5;
        SceneManager.LoadScene("Level5");
    }

    public void ToLevel6()
    {
        levelNum = 6;
        SceneManager.LoadScene("Level6");
    }

    public void ToPassScene()
    {
        SceneManager.LoadScene("PassScene");
    }

    public void ToFailScene()
    {
        SceneManager.LoadScene("FailScene");
    }

    public void ToNextLevel()
    {
        Debug.Log("去下一关");
        switch (levelNum)
        {
            case 1:
                ToLevel2();
                break;
            case 2:
                ToLevel3();
                break;
            case 3:
                ToLevel4();
                break;
            case 4:
                ToLevel5();
                break;
            case 5:
                ToLevel6();
                break;
            default:
                break;
        }
    }

    public void Remake()
    {
        switch (levelNum)
        {
            case 1:
                ToLevel1();
                break;
            case 2:
                ToLevel2();
                break;
            case 3:
                ToLevel3();
                break;
            case 4:
                ToLevel4();
                break;
            case 5:
                ToLevel5();
                break;
            case 6:
                ToLevel6();
                break;
            default:
                break;
        }
    }
}
