using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float shotRate = 2.0f;
    private float shotTime;
    public GameObject gem;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Rocket")
        {
            Shotting();
        }
    }
    private void Shotting()
    {
        shotTime += Time.deltaTime;
        if(shotTime>shotRate)
        {
            Instantiate(gem,transform.position,Quaternion.identity);
            shotTime = 0;
        }
    }
}
