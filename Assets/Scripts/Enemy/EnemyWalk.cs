using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float speed;
    public float chaseSpeed;
    public float waitTime;
    public Transform[] movePos;

    private int i = 0;
    private bool movingRight = true;
    private float wait;

    public bool isFind = false;

    public Vector3 target;

    private float maxFollowTime = 5.0f;
    private float followTime;


    void Start()
    {
        wait = waitTime;       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFind == false)
        {
            Move();//����Ѳ�ߺ���
        }
        else if (isFind == true)
        {
            Follow();//���Ǹ��溯��
            followTime += Time.deltaTime;
            if(followTime > maxFollowTime)
            {
                isFind = false;
                followTime = 0;
            }
        }

    }
    void Follow()
    {
        target = GameObject.Find("Rocket_0").GetComponent<Transform>().position;//��ȡĿ���λ��
        Vector2 position = transform.position;
        if (Mathf.Abs(gameObject.transform.position.x - target.x) > 5)//���˺ͽ�ɫ�������ĳ��ֵʱ�ſ�ʼ������ƶ�,���������˵�������ҳ��غ�
        {
            if (gameObject.transform.position.x < target.x)
            {
                position.x += speed;
                gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);//����ת��
            }
            else if (gameObject.transform.position.x >target.x)
            {
                position.x -= speed;
                gameObject.transform.localRotation = Quaternion.Euler(0, -180, 0);//����ת��
            }
            transform.position = Vector2.MoveTowards
                (transform.position, position, chaseSpeed * Time.deltaTime);
        }
    }


    private void Move()
    {
        {
            transform.position = Vector2.MoveTowards
                (transform.position, movePos[i].position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                if (movingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }

                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }

                waitTime = wait;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)//��ҽ����˵��˵��ӽǣ��������������˾ͻṥ�����
    {
        if (collision.gameObject.tag == "Rocket")//��Ҫ����ҵı�ǩ��ΪRocket
        {
            isFind = true;
        }
    }

}
