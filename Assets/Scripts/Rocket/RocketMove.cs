using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public Rigidbody2D rb;
    //��ȡ��Ч����
    private RocketFireParticles rocketFireParticles;

    [Header("��������")]
    public float pushForce;
    public Vector3 direction;

    public bool isHurt;
    public float hurtForce;

    public bool isDead=false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //��ȡ��Ч����
        rocketFireParticles = GetComponent<RocketFireParticles>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isHurt)
        if(!isDead)
        {
            FollowMouseRotate();
            FollowMouseMove();
        }
    }

    private void FollowMouseRotate()//������Rocket���������ת
    {


        //��ȡ���λ�ã������������Ļ����,Z��Ϊ0�����ﲻ��ת�� 
        Vector3 mouse = Input.mousePosition;
        //��ȡ������꣬����������������꣬��Ҫת��Ϊ��Ļ����
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        //��Ļ��������������õ����ͻ��֮�����������
        direction = mouse - obj;
        //��z�ḳֵΪ0������ƽ��ռ���
        direction.z = 0f;
        //��Ŀ���������ȱ�Ϊ1������ֻ��Ҫ�������򣬲���Ҫ���ȣ����Ա��1.
        direction = direction.normalized;
        
        if (Input.GetMouseButton(0))
        {
            transform.up = direction;//���������y����Ŀ������һ�£��ﵽ��תЧ��
            rb.constraints = RigidbodyConstraints2D.None; //����������ת      
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;//����z����ת

        }

    }

    private void FollowMouseMove()
    {

        if (Input.GetMouseButton(0))//������������ʱ
        {
            //����������Ч����
            rocketFireParticles.PlayEffect();

            //����Rocketһ��������귽�����
            rb.AddForce(transform.up * pushForce, ForceMode2D.Impulse);
        }

    }

    public void GetHurt(Transform attacker)
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.position.x), (transform.position.y - attacker.position.y)).normalized;

        rb.AddForce(dir*hurtForce, ForceMode2D.Impulse);
    }

    public void RocketDead()
    {
        isDead = true;        
    }

}
