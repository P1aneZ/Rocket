using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    private Rigidbody2D rb;

    private EnemyWalk enemyWalk;

    private Character character;

    private EnemyAttack enemyAttack;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemyWalk= GetComponent<EnemyWalk>();
        character= GetComponent<Character>();
        enemyAttack= GetComponent<EnemyAttack>();   
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
        anim.SetBool("isAttack",enemyAttack.isAttack);
    }

    public void EnemyHurt()
    {
        anim.SetTrigger("Hurt");
    }

    
}
