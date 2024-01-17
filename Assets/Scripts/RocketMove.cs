using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    [Header("基本参数")]
    public float pushForce;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowMouseRotate();
        FollowMouseMove();
    }
 
    private void FollowMouseRotate()//用来让Rocket跟随鼠标旋转
    {
        if (Input.GetMouseButton(0))
        {
            //获取鼠标位置，鼠标坐标是屏幕坐标,Z轴为0，这里不做转换 
            Vector3 mouse = Input.mousePosition;
            //获取火箭坐标，火箭坐标是世界坐标，需要转换为屏幕坐标
            Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
            //屏幕坐标向量相减，得到鼠标和火箭之间的连线向量
            Vector3 direction = mouse - obj;
            //将z轴赋值为0，置于平面空间内
            direction.z = 0f;
            //将目标向量长度变为1，这里只需要向量方向，不需要长度，所以变成1.
            direction = direction.normalized;
            //物体自身的y轴与目标向量一致，达到旋转效果
            transform.up = direction;
        }
    }

    private void FollowMouseMove()
    {

        if (Input.GetMouseButton(0))//当鼠标左键按下时
        {
            //给予Rocket一个向着鼠标方向的力
            rb.AddForce(transform.up * pushForce, ForceMode2D.Force);
        }


    }
}
