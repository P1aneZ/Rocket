using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;

    public bool isDestroyed=false;

    public bool isOpen;

    private RocketLand rocketLand;


    public float openTime;
    public float openDuration;

    private void Awake()
    {
        //openTime = 0;
        //openDuration = 3.0f;
        rb=GetComponent<Rigidbody2D>();
        rocketLand = GameObject.Find("Rocket_0").GetComponent<RocketLand>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //isDestroyed = GameObject.Find("Rocket_0").GetComponent<RocketLand>().isDestroyed;
       /* if (openTime > 0)
        {
            openTime-=Time .deltaTime;
        }
        else
        {
            isOpen=false;
        }*/
        DoorOpen(rocketLand);
    }

    private void DoorOpen(RocketLand rocketLand)
    {
        if (rocketLand.isDestroyed)//�������װ���Ƿ񱻴ݻ٣����ݻ�ʱ�ж�����
        {
            isOpen = true;
        }
        else
        {
            isOpen=false;
        }
        if (isOpen)//&&openTime>=0)
        { 

            DoorSound.PlayDoorOpen();//���ſ�����Ч


           //if(openTime==0)openTime=openDuration;
                       //rb.velocity = new Vector3(0, 2f, 0);//����һ�����ϵ��ٶ�
           //rb.transform.position=new Vector3(rb.transform.position.x,rb.transform.position.y+0.2f,rb.transform.position.z);
        }
        //else
        //{
           // rb.velocity = Vector3.zero;//������ǿ���״̬���������ŵ��ٶ���Ϊ0
        //}
    }

    public void AfterDoorOpen()
    {
        isOpen = false;
        Destroy(this.gameObject);
    }

}
