using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyWalk : MonoBehaviour
{
    public float speed;
    public float chaseSpeed;
    public float waitTime;
    public Transform[] movePos;
    public float velocity;

    public int i = 0;
    private bool movingRight = true;
    private float wait;

    public bool isFind = false;

    public Vector3 target;
    public Vector3 curpos;
    public Vector3 lastpos;

    private float maxFollowTime = 5.0f;
    private float followTime;

    public Character character;


    void Start()
    {
        wait = waitTime;
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!character.isDead)
        {
            if (isFind == false)
            {
                Move();//����Ѳ�ߺ���
            }
            else if (isFind == true)
            {
                Follow();//���Ǹ��溯��
                followTime += Time.deltaTime;
                if (followTime > maxFollowTime)
                {
                    isFind = false;
                    followTime = 0;
                }
            }
            velocity = Speed();
            if (velocity != 0)
            {
                if (!EnemySoundMale.audioSrc.isPlaying)
                {
                    EnemySoundMale.PlayEnemyWalkingGrass();//���������ڲݵ��ϵ�����
                }
            }
        }

    }
    void Follow()
    {
        if(GameObject.Find("Rocket_0"))
            target = GameObject.Find("Rocket_0").GetComponent<Transform>().position;//��ȡĿ���λ��
        Vector2 position = transform.position;
        if (Mathf.Abs(gameObject.transform.position.x - target.x) > 5)//���˺ͽ�ɫ�������ĳ��ֵʱ�ſ�ʼ������ƶ�,���������˵�������ҳ��غ�
        {
            if (gameObject.transform.position.x < target.x)
            {
                position.x += speed;
                gameObject.transform.localRotation = Quaternion.Euler(0, -180, 0);
                movingRight = true;
                //����ת��
            }
            else if (gameObject.transform.position.x > target.x)
            {
                position.x -= speed;
                gameObject.transform.localRotation = Quaternion.Euler(0, -0, 0);
                movingRight = false;
                //����ת��
            }
            transform.position = Vector2.MoveTowards
                (transform.position, position, chaseSpeed * Time.deltaTime);
        }
    }


    private void Move()
    {
        {
            transform.position = Vector2.MoveTowards
                (transform.position, movePos[i].position, speed * Time.deltaTime);//����ʼλ�ã�Ŀ��λ�ã��ƶ��ٶȣ�
        }
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;//��Ѳ�ߵ�ȴ�
            }
            else
            {
                //ת��
                if (movingRight)
                {
                    gameObject.transform.localRotation = Quaternion.Euler(0, -0, 0);
                    movingRight = false;
                }
                else
                {
                    gameObject.transform.localRotation = Quaternion.Euler(0, -180, 0);
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
        else 
        {
            if (gameObject.transform.position.x < movePos[i].position.x)
            {
                gameObject.transform.localRotation = Quaternion.Euler(0, -180, 0);
                movingRight = true;
            }
            else if (gameObject.transform.position.x > movePos[i].position.x)
            {               
                gameObject.transform.localRotation = Quaternion.Euler(0, -0, 0);
                movingRight = false;
                //����ת��
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

    public float Speed()
    {

        curpos = gameObject.transform.position;//��ǰ��
        float _speed = (Vector3.Magnitude(curpos - lastpos) / Time.deltaTime);//����һ�����������ȥ��ǰ֡����ʱ�䡣
        lastpos = curpos;//�ѵ�ǰ�㱣����һ����
        return _speed;
    }

    public void DestroyAfterAnimation()
    {
        Destroy(this.gameObject);
    }


}
