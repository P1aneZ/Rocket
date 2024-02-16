using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoadManager : MonoBehaviour
{
    //当前所在的关卡数
    [SerializeField]public static int levelNum;
    //解锁的关卡数
    int unlockedLevelIndex;
    //关卡选择第二页要隐藏第一页的东西
    public GameObject[] Page1;
    //关卡选择第二页要显示的东西
    public GameObject[] Page2; 

    [Header("事件监听")]
    //监听点击“下一关卡”事件
    public VoidEventSO nextLevel;
    //监听点击“重新开始”事件
    public VoidEventSO remake;

    public void Start()
    {
        //读取解锁的关卡数
        unlockedLevelIndex = PlayerPrefs.GetInt("unlockedLevelIndex");
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
        if(SceneManager.GetActiveScene().name == "Menu")
            SceneManager.LoadScene("levelSelectPage1");
        else
        {
            for (int i = 0; i < Page1.Length; i++)
            {
                Page1[i].SetActive(true);
            }
            for (int i = 0; i < Page2.Length; i++)
            {
                Page2[i].SetActive(false);
            }
        }

    }

    public void ToLevelSelectPage2()
    {
        for(int i = 0; i < Page1.Length; i++)
        {
            Page1[i].SetActive(false);
        }
        for(int i = 0;i < Page2.Length; i++)
        {
            Page2[i].SetActive(true);
        }

        //SceneManager.LoadScene("levelSelectPage2");
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
        Destroy(GameObject.Find("BGMManager"));
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

    public void ToLevel7()
    {
        levelNum = 7;
        SceneManager.LoadScene("Level7");
    }

    public void ToLevel8()
    {
        levelNum = 8;
        SceneManager.LoadScene("Level8");
    }

    public void ToLevel9()
    {
        levelNum = 9;
        SceneManager.LoadScene("Level9");
    }

    public void ToPassScene()
    {
        if(levelNum > unlockedLevelIndex)
        {
            unlockedLevelIndex = levelNum;
            PlayerPrefs.SetInt("unlockedLevel", unlockedLevelIndex);
        }
        SceneManager.LoadScene("PassScene");
    }

    public void ToEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void ToFailScene()
    {
        //SceneManager.LoadScene("FailScene");
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
            case 6:
                ToLevel7();
                break;
            case 7:
                ToLevel8();
                break;
            case 8:
                ToLevel9();
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
            case 7:
                ToLevel7();
                break;
            case 8:
                ToLevel8();
                break;
            case 9:
                ToLevel9();
                break;
            default:
                break;
        }
    }

}
