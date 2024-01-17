using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public bool isLand;//着陆与否

    public LayerMask LandPointLayer;//着陆点所在的层

    public float checkRadius=0.1f;//判定范围大小

    // Update is called once per frame
    void Update()
    {
        CheckLand();//一直运行CheckLand函数，判断是否着陆
    }
    private void CheckLand()
    {
        isLand=Physics2D.OverlapCircle(transform.position,checkRadius,LandPointLayer);//以transform.position为中心，checkRadius为半径的圆的范围内，在LandPointLayer上检测是否有碰撞，如果有，isLand=true
    }
}
