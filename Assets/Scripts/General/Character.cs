using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("基本属性")]
    public float maxHealth;
    public float currentHealth;

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
        invulnerableCounter -= Time.deltaTime;
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
            //触发死亡
        }


    }

    private void TriggerInvulnerable()
    {
        invulnerable = true;
        invulnerableCounter = invulnerableDuration;
    }
}
