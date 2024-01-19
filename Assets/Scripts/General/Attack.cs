using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //伤害、攻击范围、攻击速度
    public int damage;
    public float attackRange;
    public float attackRate;

    private void OnTriggerEnter2D(Collider2D other)// 这里不喷火也能造成伤害--Berluga
    {
        other.GetComponent<Character>()?.TakeDamage(this);
    }

}
