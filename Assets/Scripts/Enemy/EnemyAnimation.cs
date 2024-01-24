using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    private Rigidbody2D rb;

    private EnemyWalk enemyWalk;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemyWalk= GetComponent<EnemyWalk>();

    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();
    }
    public void SetAnimation()
    {
        anim.SetFloat("velocityX", Mathf.Abs(enemyWalk.velocity));

    }
}
