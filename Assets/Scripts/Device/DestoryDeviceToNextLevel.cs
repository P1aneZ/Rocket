using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestoryDeviceToNextLevel : MonoBehaviour
{
    //成功通关事件
    public UnityEvent Pass;

    //获取火箭
    public RocketMove rocketmove;

    //获取特效
    public GameObject rocketFireParticles;

    //获得死亡粒子动画
    public GameObject deadParticlesEffect;

    public bool isDestroyed;//是否摧毁
         
    public void CheckDestoryDeviceDead()
    {
        isDestroyed = true;//成功摧毁
        //过关事件
        StartCoroutine(PassCounter());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            Debug.Log("同归于尽");
            this.gameObject.GetComponent<Character>().isDead = true;
            //this.gameObject.GetComponent<Character>().OnDie?.Invoke();
            isDestroyed = true;

            rocketmove.enabled = false;

            //播放死亡动画
            Instantiate(deadParticlesEffect, rocketmove.transform.position, Quaternion.identity);

            //不能让火箭继续喷
            rocketFireParticles.SetActive(false);

            //过关事件
            StartCoroutine(PassCounter());
        }
    }

    private IEnumerator PassCounter()
    {
        Debug.Log("协程中");
        yield return new WaitForSeconds(1f);
        Pass?.Invoke();
        Debug.Log("协程结束");
    }


}
