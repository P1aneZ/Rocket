using UnityEngine;

public class WallHurt : MonoBehaviour
{
    public int damage;

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rocket" && other.gameObject.GetComponent<RocketMove>().velocity >= 5f)
            other.gameObject.GetComponent<Character>()?.TakeDamage(damage);
    }
}
