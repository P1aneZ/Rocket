using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public float timeLeft;
    //文本显示倒计时
    public Text timeCounter;

    private GameObject rocket;

    public bool isCounting;
    private bool isLanded=false;
    // Start is called before the first frame update
    void Start()
    {
        rocket = GameObject.FindWithTag("Rocket");
        isCounting = rocket.GetComponent<PhysicsCheck>().isWithLand;
        
        timeLeft = rocket.GetComponent<RocketLand>().landDuration;
        timeCounter.text = timeLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();

        
    }
    private void CountTime()
    {
        isCounting = rocket.GetComponent<PhysicsCheck>().isWithLand;
        //判断是否停止倒计时
        if (timeLeft <= 0 && isCounting)
        {
            isCounting = false;
            isLanded = true;
        }
        if (isCounting && !isLanded)//在计时且尚未判定着陆时
        {
            //gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
            timeLeft -= Time.deltaTime;
        }
        else
        {
            //gameObject.GetComponent<CanvasGroup>().alpha = 0f;
            timeLeft = rocket.GetComponent<RocketLand>().landDuration;
        }


        //文本显示倒计时的数字
        timeCounter.text = timeLeft.ToString();
    }
}
