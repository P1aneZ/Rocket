using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHurt : MonoBehaviour
{
    private Attack attack;
    
    void Start()
    {
        attack= GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D other)

    {
        
        if (other.gameObject.tag=="Rocket")
        other.gameObject.GetComponent<Character>()?.TakeDamage(attack);
    }
}
