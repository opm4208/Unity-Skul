using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : Player
{
    public int attackCombo=0;
    public Animator animator;
    private PlayerMove playerMove;
    public LayerMask monsetMask;
    protected override void Awake()
    {
        base.Awake(); 
        playerMove = GetComponent<PlayerMove>();
        animator = GetComponent<Animator>();
    }
    public void Hit(int damage)
    {
        hp -= damage;
        Debug.Log(hp);
    }
    private void Attack()
    {
        if (!attackCT)
        {
            if (attackCombo > 1)
                attackCombo = 0;
            attackCombo++;
            playerMove.isAttack= true;
            animator.SetInteger("AttackCount", attackCombo);
            animator.SetTrigger("Attack");
            attackCT = true;
            StartCoroutine(AttackCT());
            AttackRange();
        }   
    }
    private void OnAttack(InputValue value)
    {
        Attack();
    }
    private void AttackRange()
    {
        // ¿À¸¥ÂÊ
        if (!playerMove.rbSprite.flipX)
        {
            Vector2 attackPosition = new Vector2(transform.position.x + 0.4f, transform.position.y);
            Vector2 attackBox = new Vector2(1.5f, 1);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPosition, attackBox, 0);
            foreach (Collider2D collider in colliders)
            {
                if (monsetMask.IsContain(collider.gameObject.layer))
                {
                    collider.gameObject.GetComponent<Monster>().Hit(damage);
                }
            }
        }
        else
        {
            Vector2 attackPosition = new Vector2(transform.position.x - 0.4f, transform.position.y);
            Vector2 attackBox = new Vector2(1.5f, 1);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPosition, attackBox, 0);
            foreach (Collider2D collider in colliders)
            {
                if (monsetMask.IsContain(collider.gameObject.layer))
                {
                    collider.gameObject.GetComponent<Monster>().Hit(damage);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + 0.4f, transform.position.y), new Vector2(1.5f, 1));
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x - 0.4f, transform.position.y), new Vector2(1.5f, 1));
    }
    IEnumerator AttackCT()
    {
        yield return new WaitForSeconds(0.3f);
        playerMove.isAttack = false;
        attackCT = false;
    }

}
