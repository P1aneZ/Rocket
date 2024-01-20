using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private RocketLand rocketLand;

    private Rigidbody2D rb;

    private GameObject rocket;

    private bool isDestroyed;

    public bool isOpen;

    public float openTime;
    public float openDuration;

    private void Awake()
    {
        rocketLand = GetComponent<RocketLand>();
        openDuration = 3.0f;
        rocket = GameObject.Find("Rocket_0");
        isDestroyed = rocket.GetComponent<RocketLand>().isDestroyed;
        rb=GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (openTime > 0)
        {
            openTime-=Time .deltaTime;
        }
        else
        {
            isOpen=false;
            openTime = 0;
        }
        DoorOpen();
    }

    private void DoorOpen()
    {
        if (isDestroyed)//�������װ���Ƿ񱻴ݻ٣����ݻ�ʱ�ж�����
        {
            isOpen = true;
        }
        else
        {
            isOpen=false;
        }
        if (isOpen)
        {
            if(openTime==0)openTime=openDuration;
            rb.transform.position=new Vector3(rb.transform.position.x,rb.transform.position.y+2,rb.transform.position.z);
        }
    }

}
