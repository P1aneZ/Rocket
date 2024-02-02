using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHurt : MonoBehaviour
{    
    public int damage;        

    private void OnCollisionExit2D(Collision2D other)

    {
        
        if (other.gameObject.tag=="Rocket")// && other.GetType().ToString()=="Polygon Collider 2D")
        other.gameObject.GetComponent<Character>()?.TakeDamage(damage);
    }
}
