using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("��������")]
    public float maxHealth;
    public float currentHealth;

    [Header("�����޵�")]
    public float invulnerableDuration;
    private float invulnerableCounter;
    public bool invulnerable;

    private void Start()
    {
        //ÿ�ο�ʼ��ʱ�򣬵�ǰѪ���������Ѫ��
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
        //��������޵�״̬���Ͳ��ܵ��˺�
        if (invulnerable)
            return;

        //�����Ѫ�۲���
        if(currentHealth - attacker.damage > 0)
        {
            //��Ѫ
            currentHealth -= attacker.damage;
            //�����޵�
            TriggerInvulnerable();
        }
        else
        {
            currentHealth = 0;
            //��������
        }


    }

    private void TriggerInvulnerable()
    {
        invulnerable = true;
        invulnerableCounter = invulnerableDuration;
    }
}
