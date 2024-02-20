using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float shotRate ;//�����ٶ�
    public float shotTime;
    public GameObject gem;

    public bool isAttack = false;
    public bool isHurt = false;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isHurt)
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
    }
    private void Shotting()
    {
        if (!isHurt)
        {
            shotTime += Time.deltaTime;
          
        }
       
        if (shotTime > shotRate)
        {
            isAttack = true;
            EnemySound.PlayEnemyAttackFemale();//����Ů���˹�����Ч
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

    public void GetHurt()
    {
        isHurt = true;
    }

    public void AfterHurt()
    {
        isHurt= false;
    }
}
