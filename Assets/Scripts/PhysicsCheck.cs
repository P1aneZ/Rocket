using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public bool isLand;//��½���

    public LayerMask LandPointLayer;//��½�����ڵĲ�

    public float checkRadius=0.1f;//�ж���Χ��С

    // Update is called once per frame
    void Update()
    {
        CheckLand();//һֱ����CheckLand�������ж��Ƿ���½
    }
    private void CheckLand()
    {
        isLand=Physics2D.OverlapCircle(transform.position,checkRadius,LandPointLayer);//��transform.positionΪ���ģ�checkRadiusΪ�뾶��Բ�ķ�Χ�ڣ���LandPointLayer�ϼ���Ƿ�����ײ������У�isLand=true
    }
}
