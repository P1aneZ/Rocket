using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //�˺���������Χ�������ٶ�
    public int damage;
    public float attackRange;
    public float attackRate;

    //�ж�����Ƿ��ڹ��������
    public bool isAttack;

    private void Update()
    {
        //�����⵽���������¾ͱ��Ϊ������ڹ���
        if (Input.GetMouseButton(0))
            isAttack = true;
        else
            isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other)// ���ﲻ���Ҳ������˺�--Berluga
    {
        if (isAttack)
        {
            if (other.gameObject.CompareTag("Enemy")
                 && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
                other.GetComponent<Character>()?.TakeDamage(damage);
            else if(other.gameObject.CompareTag("DestroyDevice")&&
                other.GetType().ToString() =="UnityEngine.PolygonCollider2D")
                other.GetComponent<Character>()?.TakeDamage(damage);
        }
    }

}
