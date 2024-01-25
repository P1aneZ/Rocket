using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationMale : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;

    private Rigidbody2D rb;

    private EnemyWalk enemyWalk;

    private Character character;

    private EnemyAttackMale enemyAttack;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemyWalk = GetComponent<EnemyWalk>();
        character = GetComponent<Character>();
        enemyAttack = GetComponent<EnemyAttackMale>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();
    }
    public void SetAnimation()
    {
        anim.SetFloat("velocityX", Mathf.Abs(enemyWalk.velocity));
        anim.SetBool("isDead", character.isDead);
        anim.SetBool("isAttack", enemyAttack.isAttack);

        anim.SetBool("isHurt", character.isHurt);
    }

    public void EnemyHurt()
    {
        anim.SetBool("isHurt", character.isHurt);
    }

  
}
