using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    //����������Ӷ���
    public GameObject isHurtParticlesEffect;
    //����������Ӷ���
    public GameObject deadParticlesEffect;
    //ִ����һ�����������Ͳ�ִ����
    private bool isBoom = false;

    //Ѫ���仯���¼�
    public UnityEvent<Character> OnHealthChange;

    //���˺������¼�
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDie;

    private void Start()
    {
        //ÿ�ο�ʼ��ʱ�򣬵�ǰѪ���������Ѫ��
        currentHealth = maxHealth;
        OnHealthChange?.Invoke(this);//����Ѫ��
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

        if(GameObject.FindWithTag("DestroyDevice") && GameObject.Find("Rocket_0"))
            GameObject.FindWithTag("DestroyDevice").GetComponent<Character>().isDead = GameObject.Find("Rocket_0").GetComponent<RocketLand>().isDestroyed;//ֻҪ����ж��ʹݻ�װ����ײ��ֱ���ж�����
            /*�˴���ָ���˴ݻ�װ�����character�ű����isDead���޸�*/
    }

    public void TakeDamage(int damage)
    {
        //��������޵�״̬���Ͳ��ܵ��˺�
        if (invulnerable)
            return;

        //�����Ѫ�۲���
        if(currentHealth - damage > 0)
        {
            if (isDead) currentHealth = 0;
            //��Ѫ
            currentHealth -= damage;
            //�����޵�
            TriggerInvulnerable();
            //ִ������
            OnTakeDamage?.Invoke();
        }
        else
        {
            currentHealth = 0;
            isDead = true;//��������
            OnDie?.Invoke();
        }

        OnHealthChange?.Invoke(this);//����Ѫ��

        if(this.tag == "Rocket" && isHurtParticlesEffect != null && deadParticlesEffect != null)
        {
            //����������Ч
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
        //�����޵�״̬����ʼ�޵�ʱ�䵹��ʱ
        invulnerable = true;
        invulnerableCounter = invulnerableDuration;
    }
}
