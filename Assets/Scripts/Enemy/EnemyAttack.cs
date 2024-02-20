using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float shotRate ;//攻击速度
    public float shotTime;
    public GameObject gem;

    public bool isAttack = false;
    public bool isHurt = false;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isHurt)
        {
            if (other.tag == "Rocket")//检测是否是Rocket进入视野
            {

                Shotting();//执行射击
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
            EnemySound.PlayEnemyAttackFemale();//播放女敌人攻击音效
            shotTime = 0;//计时归0
        }
    }

    public void AfterShotting()
    {
        Vector3 pos = transform.position;
        pos.y += 1;
        Instantiate(gem, pos, Quaternion.identity);//在敌人位置生成子弹  
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
