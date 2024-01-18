using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    [Header("判断是否碰撞")]
    public bool isWithLand;//进入着陆装置判定区域与否

    public bool isWithDestroyDevice;

    public bool isWithSupplyDevice;

    [Header("判断碰撞的Layer")]
    public LayerMask LandPointLayer;//着陆装置所在的层
    public LayerMask DestroyDeviceLayer;
    public LayerMask SupplyDeviceLayer;
    [Header("判断碰撞的半径")]
    public float checkRadius=0.1f;//判定范围大小

    // Update is called once per frame
    void Update()
    {
        CheckLand();//一直运行CheckLand函数，判断是否进入着陆装置判定区域
        CheckDestroy();
        CheckSupply();
    }
    private void CheckLand()
    {
        isWithLand=Physics2D.OverlapCircle(transform.position,checkRadius,LandPointLayer);//以transform.position为中心，checkRadius为半径的圆的范围内，在LandPointLayer上检测是否有碰撞，如果有，isLand=true
    }

    public void CheckDestroy()
    {
        isWithDestroyDevice=Physics2D.OverlapCircle(transform.position,checkRadius,DestroyDeviceLayer);
    }

    private void CheckSupply()
    {
        isWithSupplyDevice = Physics2D.OverlapCircle(transform.position,checkRadius,SupplyDeviceLayer);
    }
}
