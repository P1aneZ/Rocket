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

    GameObject timecounter;
    // Start is called before the first frame update
    void Start()
    {
        timecounter = GameObject.FindWithTag("TimeCounter");
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
            timecounter.SetActive(true);
            timeLeft -= Time.deltaTime;
        }
        else
        {
            //gameObject.GetComponent<CanvasGroup>().alpha = 0f;
            timecounter.SetActive(false);
            timeLeft = rocket.GetComponent<RocketLand>().landDuration;
        }


        //�ı���ʾ����ʱ������
        timeCounter.text = timeLeft.ToString();
    }
}
