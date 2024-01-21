using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //最大生命值，当前生命值，是否死亡的状态
    [Header("基本属性")]
    public float maxHealth;
    public float currentHealth;
    public bool isDead=false;

    //受伤无敌持续时间，计时器，是否无敌的状态
    [Header("受伤无敌")]
    public float invulnerableDuration;
    private float invulnerableCounter;
    public bool invulnerable;

    private void Start()
    {
        //每次开始的时候，当前血量等于最大血量
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //无敌时间倒计时
        invulnerableCounter -= Time.deltaTime;

        //当无敌时间倒计时结束时，取消无敌状态
        if(invulnerableCounter <= 0)
        {
            invulnerable = false;
        }
    }

    public void TakeDamage(Attack attacker)
    {
        //如果处于无敌状态，就不受到伤害
        if (invulnerable)
            return;

        //如果扣血扣不死
        if(currentHealth - attacker.damage > 0)
        {
            //扣血
            currentHealth -= attacker.damage;
            //触发无敌
            TriggerInvulnerable();
        }
        else
        {
            currentHealth = 0;
            isDead = true;//触发死亡
        }


    }

    private void TriggerInvulnerable()
    {
        //触发无敌状态，开始无敌时间倒计时
        invulnerable = true;
        invulnerableCounter = invulnerableDuration;
    }
}
