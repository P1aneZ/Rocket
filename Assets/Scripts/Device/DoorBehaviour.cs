using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{  
    public bool isDestroyed=false;

    public bool isOpen;

    public DestoryDevice destoryDevice;

    public float openTime;
    public float openDuration;
   
    // Update is called once per frame
    void Update()
    {   
        DoorOpen(destoryDevice);
    }

    private void DoorOpen(DestoryDevice destoryDevice)
    {
        if (destoryDevice.isDestroyed)//�������װ���Ƿ񱻴ݻ٣����ݻ�ʱ�ж�����
        {
            isOpen = true;
        }
        else
        {
            isOpen=false;
        }
        if (isOpen)
        { 
            DoorSound.PlayDoorOpen();//���ſ�����Ч         
        }       
    }

    public void AfterDoorOpen()
    {
        isOpen = false;
        Destroy(this.gameObject);
    }

}
