using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SupplyedLaunchDevice : MonoBehaviour
{
    private GameObject rocket;
    private PhysicsCheck physicsCheck;
    public  GameObject supplyDevice;

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
    // Start is called before the first frame update
    void Awake()
    {
        rocket = GameObject.Find("Rocket_0");
        physicsCheck= rocket.GetComponent<PhysicsCheck>();

        CounterText = CounterUI.GetComponent<TMP_Text>();

        TakeOff();//起飞
    }
    void Update()
    {
        if (supplyDevice.GetComponent<SupplyDevice>().isSupplied)
        {
            IfLand();
        }
        else
        {
            //关闭倒计时
            CounterUI.SetActive(false);
        }
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
    private void TakeOff()
    {
        rocket.transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
        //将火箭的坐标赋值为起飞装置的坐标                                                                                                                                                                 //this指当前类
    }
}
