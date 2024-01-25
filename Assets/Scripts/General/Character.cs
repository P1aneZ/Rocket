using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    private RocketLand rocketLand;
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

    //获得受伤粒子动画
    public GameObject isHurtParticlesEffect;
    //获得死亡粒子动画
    public GameObject deadParticlesEffect;
    //执行完一遍死亡动画就不执行了
    private bool isBoom = false;

    //血条变化的事件
    public UnityEvent<Character> OnHealthChange;

    //受伤和死亡事件
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDie;

    private void Start()
    {
        //每次开始的时候，当前血量等于最大血量
        currentHealth = maxHealth;
        OnHealthChange?.Invoke(this);//传递血量
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

        if(GameObject.FindWithTag("DestroyDevice") && GameObject.Find("Rocket_0"))
            GameObject.FindWithTag("DestroyDevice").GetComponent<Character>().isDead = GameObject.Find("Rocket_0").GetComponent<RocketLand>().isDestroyed;//只要火箭判定和摧毁装置碰撞，直接判定死亡
            /*此处是指定了摧毁装置里的character脚本里的isDead被修改*/
    }

    public void TakeDamage(int damage)
    {
        //如果处于无敌状态，就不受到伤害
        if (invulnerable)
            return;

        //如果扣血扣不死
        if(currentHealth - damage > 0)
        {
            if (isDead) currentHealth = 0;
            //扣血
            currentHealth -= damage;
            //触发无敌
            TriggerInvulnerable();
            //执行受伤
            OnTakeDamage?.Invoke();
        }
        else
        {
            currentHealth = 0;
            isDead = true;//触发死亡
            OnDie?.Invoke();
        }

        OnHealthChange?.Invoke(this);//传递血量

        if(this.tag == "Rocket" && isHurtParticlesEffect != null && deadParticlesEffect != null)
        {
            //播放粒子特效
            if(isDead && (isBoom == false))
            {
                Instantiate(deadParticlesEffect,this.transform.position , Quaternion.identity);
                isBoom = true;
            }
            else
            {
                if(!isDead)
                    Instantiate(isHurtParticlesEffect, this.transform.position, Quaternion.identity);
            }

        }


    }

    private void TriggerInvulnerable()
    {
        //触发无敌状态，开始无敌时间倒计时
        invulnerable = true;
        invulnerableCounter = invulnerableDuration;
    }
}
