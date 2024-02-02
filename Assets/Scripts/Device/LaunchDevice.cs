using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchDevice : MonoBehaviour
{
    private GameObject rocket;
    // Start is called before the first frame update
    void Awake()
    {
        rocket = GameObject.Find("Rocket_0");
        
        TakeOff();//起飞
    }

    private void TakeOff()
    {
        rocket.transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
        //将火箭的坐标赋值为起飞装置的坐标                                                                                                                                                                 //this指当前类
    }
}
