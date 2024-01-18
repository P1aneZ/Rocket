using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketMove : MonoBehaviour
{
    private Rigidbody2D rb;
    //获取特效代码
    private RocketFireParticles rocketFireParticles;

    [Header("基本参数")]
    public float pushForce;
    public Vector3 direction;
    public float cosAngle;
    public float angle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //获取特效代码
        rocketFireParticles = GetComponent<RocketFireParticles>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouseRotate();
        FollowMouseMove();
    }

    private void FollowMouseRotate()//用来让Rocket跟随鼠标旋转
    {


        //获取鼠标位置，鼠标坐标是屏幕坐标,Z轴为0，这里不做转换 
        Vector3 mouse = Input.mousePosition;
        //获取火箭坐标，火箭坐标是世界坐标，需要转换为屏幕坐标
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        //屏幕坐标向量相减，得到鼠标和火箭之间的连线向量
        direction = mouse - obj;
        //将z轴赋值为0，置于平面空间内
        direction.z = 0f;
        //将目标向量长度变为1，这里只需要向量方向，不需要长度，所以变成1.
        direction = direction.normalized;
        /*
        if (Input.GetMouseButton(1))
        {
            // transform.up = direction;
            //创建临时变量faceDir，表示Rocket的x轴朝向
            float faceDir = transform.localScale.x;
            if (direction.x > 0f)
            {
                faceDir = 0.05f;
            }
            if (direction.x < 0f)
            {
                faceDir = -0.05f;
            }
            //更改图片比例，来让rocket实现翻转
            transform.localScale = new Vector3(faceDir, 0.05f, 0f);
        }
        */
    }

    private void FollowMouseMove()
    {

        if (Input.GetMouseButton(0))//当鼠标左键按下时
        {
            //播放粒子特效播放
            rocketFireParticles.PlayEffect();

            //给予Rocket一个向着鼠标方向的力
            rb.AddForce(transform.up * pushForce, ForceMode2D.Impulse);
        }

    }
}
