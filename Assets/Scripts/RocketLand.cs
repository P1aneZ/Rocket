using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLand : MonoBehaviour
{
    private PhysicsCheck physicsCheck;
    private Rigidbody2D rb;

    [Header("所需时长")]
    public float landDuration = 3.0f;
    public float supplyDuration = 3.0f;
    private float landTime,supplyTime;

    [Header("判断是否成功")]
    public bool isLand;//成功着陆
    public bool isSupplied;//成功补给
    public bool isDestroyed;//成功摧毁


    private void Awake()
    {
        //获取组件
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        supplyTime = 0;
        landTime = 0;
    }
    void Update()
    {
        if (landTime > 0)landTime -= Time.deltaTime;
        if (supplyTime > 0)supplyTime -= Time.deltaTime;
        Land();
        Destroy();
        Supply();
    }
    private void Land() //检测到与着陆点碰撞就执行的函数
    {
        if (physicsCheck.isWithLand)//假如判定在着陆装置范围内 
        {
            //初始化计时并开始计时
            if(landTime==0)landTime = landDuration;
            if (landTime <= 0&&physicsCheck.isWithLand)//计时时间到且火箭依然在着陆装置范围内
            {
                isLand = true;//判定成功着陆
                landTime = 0;
            }
            
            /*transform.position = new Vector3(-5f, 0, 0); 
            rb.velocity = new Vector3(0,0,0);*/
        }
        
    }

    private void Supply()
    {
        if (physicsCheck.isWithSupplyDevice)//代码逻辑同Land();
        {
            if(supplyTime==0)supplyTime = supplyDuration;
            if (supplyTime <= 0 && physicsCheck.isWithSupplyDevice)
            {
                isSupplied = true;
                supplyTime = 0;
            }
        }
    }

    private void Destroy()
    {
        if(physicsCheck.isWithDestroyDevice)
        {
            isDestroyed = true;//判定为已经摧毁
        }
    }
}
