using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private RocketLand rocketLand;
    //�������ֵ����ǰ����ֵ���Ƿ�������״̬
    [Header("��������")]
    public float maxHealth;
    public float currentHealth;
    public bool isDead=false;

    //�����޵г���ʱ�䣬��ʱ�����Ƿ��޵е�״̬
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
        //�޵�ʱ�䵹��ʱ
        invulnerableCounter -= Time.deltaTime;

        //���޵�ʱ�䵹��ʱ����ʱ��ȡ���޵�״̬
        if(invulnerableCounter <= 0)
        {
            invulnerable = false;
        }
        GameObject.Find("�ݻ�װ��").GetComponent<Character>().isDead = GameObject.Find("Rocket_0").GetComponent<RocketLand>().isDestroyed;//ֻҪ����ж��ʹݻ�װ����ײ��ֱ���ж�����
        /*�˴���ָ���˴ݻ�װ�����character�ű����isDead���޸�*/
    }

    public void TakeDamage(Attack attacker)
    {
        //��������޵�״̬���Ͳ��ܵ��˺�
        if (invulnerable)
            return;

        //�����Ѫ�۲���
        if(currentHealth - attacker.damage > 0)
        {
            if (isDead) currentHealth = 0;
            //��Ѫ
            currentHealth -= attacker.damage;
            //�����޵�
            TriggerInvulnerable();
        }
        else
        {
            currentHealth = 0;
            isDead = true;//��������
        }


    }

    private void TriggerInvulnerable()
    {
        //�����޵�״̬����ʼ�޵�ʱ�䵹��ʱ
        invulnerable = true;
        invulnerableCounter = invulnerableDuration;
    }
}
