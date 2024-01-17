using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    [Header("��������")]
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
 
    private void FollowMouseRotate()//������Rocket���������ת
    {
        if (Input.GetMouseButton(0))
        {
            //��ȡ���λ�ã������������Ļ����,Z��Ϊ0�����ﲻ��ת�� 
            Vector3 mouse = Input.mousePosition;
            //��ȡ������꣬����������������꣬��Ҫת��Ϊ��Ļ����
            Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
            //��Ļ��������������õ����ͻ��֮�����������
            Vector3 direction = mouse - obj;
            //��z�ḳֵΪ0������ƽ��ռ���
            direction.z = 0f;
            //��Ŀ���������ȱ�Ϊ1������ֻ��Ҫ�������򣬲���Ҫ���ȣ����Ա��1.
            direction = direction.normalized;
            //���������y����Ŀ������һ�£��ﵽ��תЧ��
            transform.up = direction;
        }
    }

    private void FollowMouseMove()
    {

        if (Input.GetMouseButton(0))//������������ʱ
        {
            //����Rocketһ��������귽�����
            rb.AddForce(transform.up * pushForce, ForceMode2D.Force);
        }


    }
}
