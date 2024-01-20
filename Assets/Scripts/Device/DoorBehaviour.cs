using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;

    public bool isDestroyed=false;

    public bool isOpen;


    public float openTime;
    public float openDuration;

    private void Awake()
    {
        openTime = 0;
        openDuration = 3.0f;
        rb=GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isDestroyed = GameObject.Find("Rocket_0").GetComponent<RocketLand>().isDestroyed;
        if (openTime > 0)
        {
            openTime-=Time .deltaTime;
        }
        else
        {
            isOpen=false;
        }
        DoorOpen();
    }

    private void DoorOpen()
    {
        if (isDestroyed)//持续检测装置是否被摧毁，仅摧毁时判定开门
        {
            isOpen = true;
        }
        else
        {
            isOpen=false;
        }
        if (isOpen&&openTime>=0)
        {
            if(openTime==0)openTime=openDuration;
            rb.velocity = new Vector3(0, 2f, 0);
            //rb.transform.position=new Vector3(rb.transform.position.x,rb.transform.position.y+0.2f,rb.transform.position.z);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

}
