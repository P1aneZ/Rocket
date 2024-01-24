using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMale : MonoBehaviour
{
    // Start is called before the first frame update
    public float shotRate = 2.0f;//攻击速度
    private float shotTime;
    public GameObject gem;

    public bool isAttack = false;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Rocket")//检测是否是Rocket进入视野
        {

            Shotting();//执行射击
        }
    }
    private void Shotting()
    {

        shotTime += Time.deltaTime;
        isAttack = true;
        if (shotTime > shotRate)
        {
            isAttack = true;
            EnemySoundMale.PlayEnemyAttackmale();//播放男敌人攻击音效

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
}
