using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    [Header("监听事件")]
    //场景是否正在加载
    public SceneLoadEventSO loadEvent;
    //场景是否加载完成
    public VoidEventSO afterSceneLoadedEvent;
    //是否进入游玩场景
    public VoidEventSO beginPlayGame;

    public Rigidbody2D rb;
    public AudioSource audioSource;
    //获取特效代码
    private RocketFireParticles rocketFireParticles;

    [Header("基本参数")]
    
    public float pushForce;
    public Vector3 direction;

    public bool isHurt;
    public float hurtForce;

    public bool isDead = false;
    private bool isLoad = false;
    private bool isPlay = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //获取特效代码
        rocketFireParticles = GetComponent<RocketFireParticles>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isHurt)
        if (!isDead && !isLoad && isPlay)
        {
            FollowMouseRotate();
            FollowMouseMove();
        }
    }

    private void OnEnable()
    {
        loadEvent.LoadRequestEvent += OnLoadEvent;
        afterSceneLoadedEvent.OnEventRaised += OnAfterSceneLoadedEvent;
        beginPlayGame.OnEventRaised += beginPlay;
    }

    private void OnDisable()
    {
        loadEvent.LoadRequestEvent -= OnLoadEvent;
        afterSceneLoadedEvent.OnEventRaised -= OnAfterSceneLoadedEvent;
        beginPlayGame.OnEventRaised -= beginPlay;
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

        if (Input.GetMouseButton(0))
        {
            transform.up = direction;//物体自身的y轴与目标向量一致，达到旋转效果
            rb.constraints = RigidbodyConstraints2D.None; //允许自由旋转      
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;//锁定z轴旋转

        }

    }

    private void FollowMouseMove()
    {

        if (Input.GetMouseButton(0))//当鼠标左键按下时
        {
            //播放移动音效
            if(!RocketSound.audioSrc.isPlaying)
            {
                RocketSound.PlayRocketMoving();
            }

            //播放粒子特效播放
            rocketFireParticles.PlayEffect();

            //给予Rocket一个向着鼠标方向的力
            rb.AddForce(transform.up * pushForce, ForceMode2D.Impulse);
        }
        else
        {
            audioSource.Stop();
        }

    }

    public void GetHurt(Transform attacker)
    {
        isHurt = true;
        if (attacker.gameObject.tag == "Gem")
        {
            rb.velocity = Vector2.zero;
            Vector2 dir = new Vector2((transform.position.x - attacker.position.x), (transform.position.y - attacker.position.y)).normalized;

            rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);
        }

    }

    public void RocketDead()
    {
        isDead = true;
    }

    private void OnLoadEvent(GameSceneSO arg0, Vector3 arg1, bool arg2)
    {
        isLoad = true;
    }

    private void OnAfterSceneLoadedEvent()
    {
        isLoad = false;
    }

    private void beginPlay()
    {
        isPlay = true;
    }
}
