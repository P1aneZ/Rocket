using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //伤害、攻击范围、攻击速度
    public int damage;
    public float attackRange;
    public float attackRate;

    //判断玩家是否在攻击（喷火）
    public bool isAttack;

    private void Update()
    {
        //如果检测到鼠标左键按下就标记为玩家正在攻击
        if (Input.GetMouseButton(0))
            isAttack = true;
        else
            isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other)// 这里不喷火也能造成伤害--Berluga
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
