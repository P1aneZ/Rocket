using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public float timeLeft;
    //�ı���ʾ����ʱ
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
        //�ж��Ƿ�ֹͣ����ʱ
        if (timeLeft <= 0 && isCounting)
        {
            isCounting = false;
            isLanded = true;
        }
        if (isCounting && !isLanded)//�ڼ�ʱ����δ�ж���½ʱ
        {
            //gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
            timeLeft -= Time.deltaTime;
        }
        else
        {
            //gameObject.GetComponent<CanvasGroup>().alpha = 0f;
            timeLeft = rocket.GetComponent<RocketLand>().landDuration;
        }


        //�ı���ʾ����ʱ������
        timeCounter.text = timeLeft.ToString();
    }
}
