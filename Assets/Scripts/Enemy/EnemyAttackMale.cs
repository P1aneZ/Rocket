using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyAttackMale : MonoBehaviour
{
    // Start is called before the first frame update
    public float shotRate = 2.0f;//�����ٶ�
    private float shotTime;
    public GameObject gem;

    public bool isAttack = false;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Rocket")//����Ƿ���Rocket������Ұ
        {
            Shotting();//ִ�����
        }
        else
        {
            shotTime = 0;
        }
    }
    private void Shotting()
    {

        shotTime += Time.deltaTime;
        isAttack = true;
        if (shotTime > shotRate)
        {
            
            EnemySoundMale.PlayEnemyAttackmale();//�����е��˹�����Ч

            shotTime = 0;//��ʱ��0
        }
    }

    public void AfterShotting()
    {
        Vector3 pos = transform.position;
        pos.y += 1;
        Instantiate(gem, pos, Quaternion.identity);//�ڵ���λ�������ӵ�  
        isAttack = false;
    }
}
