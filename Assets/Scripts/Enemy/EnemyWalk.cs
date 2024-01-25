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
                Move();//这是巡逻函数
            }
            else if (isFind == true)
            {
                Follow();//这是跟随函数
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
                    EnemySoundMale.PlayEnemyWalkingGrass();//播放行走在草地上的音乐
                }
            }
        }

    }
    void Follow()
    {
        if(GameObject.Find("Rocket_0"))
            target = GameObject.Find("Rocket_0").GetComponent<Transform>().position;//获取目标的位置
        Vector2 position = transform.position;
        if (Mathf.Abs(gameObject.transform.position.x - target.x) > 5)//敌人和角色距离大于某个值时才开始朝玩家移动,这样避免了敌人与玩家冲重合
        {
            if (gameObject.transform.position.x < target.x)
            {
                position.x += speed;
                gameObject.transform.localRotation = Quaternion.Euler(0, -180, 0);
                movingRight = true;
                //敌人转向
            }
            else if (gameObject.transform.position.x > target.x)
            {
                position.x -= speed;
                gameObject.transform.localRotation = Quaternion.Euler(0, -0, 0);
                movingRight = false;
                //敌人转向
            }
            transform.position = Vector2.MoveTowards
                (transform.position, position, chaseSpeed * Time.deltaTime);
        }
    }


    private void Move()
    {
        {
            transform.position = Vector2.MoveTowards
                (transform.position, movePos[i].position, speed * Time.deltaTime);//（初始位置，目标位置，移动速度）
        }
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;//在巡逻点等待
            }
            else
            {
                //转向
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
                //敌人转向
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)//玩家进入了敌人的视角（触发器），敌人就会攻击玩家
    {
        if (collision.gameObject.tag == "Rocket")//需要将玩家的标签设为Rocket
        {
            isFind = true;
        }
    }

    public float Speed()
    {

        curpos = gameObject.transform.position;//当前点
        float _speed = (Vector3.Magnitude(curpos - lastpos) / Time.deltaTime);//与上一个点做计算除去当前帧花的时间。
        lastpos = curpos;//把当前点保存下一次用
        return _speed;
    }

    public void DestroyAfterAnimation()
    {
        Destroy(this.gameObject);
    }


}
