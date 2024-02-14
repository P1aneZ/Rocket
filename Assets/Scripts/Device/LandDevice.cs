using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class LandDevice : MonoBehaviour
{
    private PhysicsCheck physicsCheck;
    private GameObject rocket;
    //获取倒计时UI
    public GameObject CounterUI;
    public TMP_Text CounterText;  

    [Header("所需时长")]
    public float landDuration = 3.0f;

    public float landTime;

    [Header("判断是否成功")]
    public bool isLand = false;//成功着陆


    //成功着陆事件
    public UnityEvent Pass;

    private void Awake()
    {
        //获取组件
        rocket = GameObject.Find("Rocket_0");
        physicsCheck = rocket.GetComponent<PhysicsCheck>();
        CounterText = CounterUI.GetComponent<TMP_Text>();

        landTime = landDuration;
    }
    void Update()
    {
        IfLand();
    }
    private void IfLand() //检测到与着陆点碰撞就执行的函数
    {
        if (physicsCheck.isWithLand)//假如判定在着陆装置范围内 
        {
            //倒计时,保留一位小数
            CounterText.text = landTime.ToString("0.0");
            //打开倒计时
            CounterUI.SetActive(true);

            if (landTime > 0)
            {
                landTime -= Time.deltaTime;
            }

            if (landTime <= 0)//计时时间到且火箭依然在着陆装置范围内
            {
                CounterUI.SetActive(false);//关闭倒计时
                isLand = true;//判定成功着陆
                Pass?.Invoke();//过关事件

            }            
        }
        else
        {
            landTime = landDuration;

            //关闭倒计时
            CounterUI.SetActive(false);
        }

    }
}
