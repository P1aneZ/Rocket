using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestoryDeviceToNextLevel : MonoBehaviour
{
    //�ɹ�ͨ���¼�
    public UnityEvent Pass;

    //��ȡ���
    public RocketMove rocketmove;

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
