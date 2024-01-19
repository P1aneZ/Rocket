using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public float speed;

    private float maxLifeTime = 5.0f;
    private float lifeTime;

    public int damage;
    public float attackRange;
    public float attackRate;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Rocket_0").GetComponent<Transform>();//±¨´í£¬object reference not set to an instance of an object
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rocket")
        {
            Destroy(gameObject);
        }
    }
}
