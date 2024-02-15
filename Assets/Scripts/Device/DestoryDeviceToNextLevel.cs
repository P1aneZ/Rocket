using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Events;

public class DestoryDeviceToNextLevel : MonoBehaviour
{
    //�ɹ�ͨ���¼�
    public UnityEvent Pass;

    //��ȡ���
    public RocketMove rocketmove;
    public Rigidbody2D rb;
    public SpriteRenderer sp;

    //��ȡ��Ч
    public GameObject rocketFireParticles;

    //����������Ӷ���
    public GameObject deadParticlesEffect;

    public bool isDestroyed;//�Ƿ�ݻ�


    public void CheckDestoryDeviceDead()
    {
        isDestroyed = true;//�ɹ��ݻ�
        //�����¼�
        StartCoroutine(PassCounter());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            Debug.Log("ͬ���ھ�");
            this.gameObject.GetComponent<Character>().isDead = true;
            //this.gameObject.GetComponent<Character>().OnDie?.Invoke();
            isDestroyed = true;

            rocketmove.enabled = false;

            //������������
            Instantiate(deadParticlesEffect, rocketmove.transform.position, Quaternion.identity);

            //�����û��������
            rocketFireParticles.SetActive(false);

            //�ص���������������û���ٶ�Ϊ0
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;

            //���ͼ����ʧ
            Debug.Log("��ʧ�ɣ�");

            // ��ȡ����ͼ�ĳ�ʼ��ɫ
            Color color = sp.color;
            // ����͸����Ϊ0.5
            color.a = 0f;
            // ����ɫӦ�õ�����ͼ��
            sp.color = color;

            //�����¼�
            StartCoroutine(PassCounter());
        }
    }

    private IEnumerator PassCounter()
    {
        Debug.Log("Э����");
        yield return new WaitForSeconds(1f);
        Pass?.Invoke();
        Debug.Log("Э�̽���");
    }


}
