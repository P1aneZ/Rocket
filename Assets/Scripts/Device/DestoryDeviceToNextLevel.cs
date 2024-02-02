using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDeviceToNextLevel : MonoBehaviour
{
    public bool isDestroyed;//是否摧毁
         
    public void CheckDestoryDeviceDead()
    {
        isDestroyed = true;//成功摧毁
        //过关事件
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            Debug.Log("同归于尽");
            this.gameObject.GetComponent<Character>().isDead = true;
            this.gameObject.GetComponent<Character>().OnDie?.Invoke();
            isDestroyed = true;
            //过关事件
        }
    }
}
