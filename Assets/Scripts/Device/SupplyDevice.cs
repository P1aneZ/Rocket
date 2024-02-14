using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SupplyDevice : MonoBehaviour
{
    private GameObject rocket;
    private PhysicsCheck physicsCheck;

    //获取倒计时UI
    public GameObject CounterUI;
    public TMP_Text CounterText;

    [Header("所需时长")]
    public float supplyDuration = 3.0f;
    public float supplyTime;

    [Header("判断是否成功")]
    public bool isSupplied = false;//成功补给

    void Start()
    {
        rocket = GameObject.Find("Rocket_0");
        physicsCheck = rocket.GetComponent<PhysicsCheck>();
        supplyTime = supplyDuration;

        CounterText = CounterUI.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        IfSupply();
    }

    private void IfSupply()
    {
        //倒计时,保留一位小数
        CounterText.text = supplyTime.ToString("0.0");
        //打开倒计时
        CounterUI.SetActive(true);

        if (physicsCheck.isWithSupplyDevice)
        {
            if (supplyTime > 0)
            {
                supplyTime-=Time.deltaTime;
            }
            if (supplyTime <= 0 )
            {
                isSupplied = true;
                //补给完毕

                //关闭倒计时
                CounterUI.SetActive(false);
            }
        }
        else
        {
            supplyTime = supplyDuration;

            //关闭倒计时
            CounterUI.SetActive(false);
        }
    }
}
