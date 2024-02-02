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
        if (destoryDevice.isDestroyed)//持续检测装置是否被摧毁，仅摧毁时判定开门
        {
            isOpen = true;
        }
        else
        {
            isOpen=false;
        }
        if (isOpen)
        { 
            DoorSound.PlayDoorOpen();//播放开门音效         
        }       
    }

    public void AfterDoorOpen()
    {
        isOpen = false;
        Destroy(this.gameObject);
    }

}
