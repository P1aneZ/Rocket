using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDevice : MonoBehaviour
{
    public bool isDestroyed;

    public int damage;

    public void CheckDestoryDeviceDead()
    {
        isDestroyed = true;//�ɹ��ݻ� 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            Debug.Log("ͬ���ھ�");
            other.gameObject.GetComponent<Character>().isDead = true;
            other.gameObject.GetComponent<Character>().OnDie?.Invoke();
            other.gameObject.GetComponent<Character>()?.TakeDamage(damage);
            this.gameObject.GetComponent<Character>().isDead = true;
            this.gameObject.GetComponent<Character>().OnDie?.Invoke();
            isDestroyed = true;
            //��Ҫ������Ź����¼�
        }
    }
}
