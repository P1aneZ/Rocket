using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float shotRate = 2.0f;//�����ٶ�
    private float shotTime;
    public GameObject gem;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Rocket")//����Ƿ���Rocket������Ұ
        {
            Shotting();//ִ�����
        }
    }
    private void Shotting()
    {
        shotTime += Time.deltaTime;
        if (shotTime > shotRate)
        {
            EnemySound.PlayEnemyAttackFemale();//����Ů���˹�����Ч
            Instantiate(gem, transform.position, Quaternion.identity);//�ڵ���λ�������ӵ�
            shotTime = 0;//��ʱ��0
        }
    }
}
