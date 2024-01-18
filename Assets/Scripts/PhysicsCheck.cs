using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    [Header("�ж��Ƿ���ײ")]
    public bool isWithLand;//������½װ���ж��������

    public bool isWithDestroyDevice;

    public bool isWithSupplyDevice;

    [Header("�ж���ײ��Layer")]
    public LayerMask LandPointLayer;//��½װ�����ڵĲ�
    public LayerMask DestroyDeviceLayer;
    public LayerMask SupplyDeviceLayer;
    [Header("�ж���ײ�İ뾶")]
    public float checkRadius=0.1f;//�ж���Χ��С

    // Update is called once per frame
    void Update()
    {
        CheckLand();//һֱ����CheckLand�������ж��Ƿ������½װ���ж�����
        CheckDestroy();
        CheckSupply();
    }
    private void CheckLand()
    {
        isWithLand=Physics2D.OverlapCircle(transform.position,checkRadius,LandPointLayer);//��transform.positionΪ���ģ�checkRadiusΪ�뾶��Բ�ķ�Χ�ڣ���LandPointLayer�ϼ���Ƿ�����ײ������У�isLand=true
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
