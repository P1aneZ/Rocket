using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject rocket;
    private GameObject launchDevice;

    private RocketLand rocketLand;

    // Start is called before the first frame update
    void Awake()
    {
        rocket = GameObject.Find("Rocket_0");
        launchDevice = GameObject.Find("起飞装置");
        TakeOff();//起飞
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeOff()
    {
        rocket.transform.position=new Vector3(launchDevice.transform.position.x, launchDevice.transform.position.y+0.25f, launchDevice.transform.position.z);//将火箭的坐标赋值为起飞装置的坐标
        //this指当前类
    }

    private void CheckSupply()
    {
        if(rocketLand.isSupplied)
        {
            //执行补给的动作
            GetComponent<RocketLand>().isSupplied = false;
        }

    }

    private void CheckDestroy()
    {
        if(rocketLand.isDestroyed)
        {
            //执行摧毁的动作
            GetComponent<RocketLand>().isDestroyed = false;
        }
    }

    private void CheckLand()
    {
        if (rocketLand.isLand)
        {
            //执行着陆的函数
            GetComponent<RocketLand>().isLand=false;
        }
    }
}
