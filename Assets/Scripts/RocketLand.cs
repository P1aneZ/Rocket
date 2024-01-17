using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLand : MonoBehaviour
{
    private PhysicsCheck physicsCheck;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
    }
    void Update()
    {
        Land();
    }
    private void Land() //检测到与着陆点碰撞就执行的函数
    {
        if (physicsCheck.isLand == true) 
        {
            transform.position = new Vector3(-5f, 0, 0); 
            rb.velocity = new Vector3(0,0,0);
        }
        
    }
}
