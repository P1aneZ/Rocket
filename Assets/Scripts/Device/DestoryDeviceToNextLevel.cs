using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDeviceToNextLevel : MonoBehaviour
{
    public bool isDestroyed;//是否摧毁

    private GameObject rocket;
    private PhysicsCheck physicsCheck; 

    private void Start()
    {
        rocket = GameObject.Find("Rocket_0");
        physicsCheck = rocket.GetComponent<PhysicsCheck>();
    }

    private void Update()
    {
        IfDestroy();
    }
    public void IfDestroy()
    {
        if (physicsCheck.isWithDestroyDevice)
        {
            isDestroyed = true;//判定为已经摧毁
            //触发过关事件
        }
    }
    public void CheckDestoryDeviceDead()
    {
        isDestroyed = true;//成功摧毁
        //过关事件
    }
}
