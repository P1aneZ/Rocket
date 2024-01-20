using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 target;//目标
    public Vector3 path;
    public Vector3 pos;
    public float speed;//子弹速度

    private float maxLifeTime = 2.0f;
    private float lifeTime;

    public int damage;
    public float attackRange;
    public float attackRate;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = rb.position;
        target = GameObject.Find("Rocket_0").GetComponent<Transform>().position;//获取目标的位置
        target.z = 0;// // 因为是2D，用不到z轴。使将z轴的值为0，这样目标的坐标就在(x,y)平面上了
        path = target - pos; //获取弹道向量
        path.z = 0;

        //子弹角度
        float fireAngle = Vector2.Angle( path, Vector2.up);

        if (pos.x > this.transform.position.x)
        {
            fireAngle = -fireAngle;
        }

        rb.velocity = path.normalized * speed;//发射子弹

        rb.transform.eulerAngles = new Vector3(0, 0, fireAngle);//角度

    }

    // Update is called once per frame
    void Update()
    {
        
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {                
            Destroy(gameObject);        
    }
}
