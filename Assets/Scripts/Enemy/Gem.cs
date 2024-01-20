using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 target;//Ŀ��
    public Vector3 path;
    public Vector3 pos;
    public float speed;//�ӵ��ٶ�

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
        target = GameObject.Find("Rocket_0").GetComponent<Transform>().position;//��ȡĿ���λ��
        target.z = 0;// // ��Ϊ��2D���ò���z�ᡣʹ��z���ֵΪ0������Ŀ����������(x,y)ƽ������
        path = target - pos; //��ȡ��������
        path.z = 0;

        //�ӵ��Ƕ�
        float fireAngle = Vector2.Angle( path, Vector2.up);

        if (pos.x > this.transform.position.x)
        {
            fireAngle = -fireAngle;
        }

        rb.velocity = path.normalized * speed;//�����ӵ�

        rb.transform.eulerAngles = new Vector3(0, 0, fireAngle);//�Ƕ�

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
