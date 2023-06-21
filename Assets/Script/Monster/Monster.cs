using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int maxHp;
    protected int hp;
    protected int damage;
    protected float attackRange;
    protected int coolTime;

    protected new Rigidbody2D rigidbody;
    protected Animator animator;
    protected new Collider2D collider;

    public int MaxHp { get { return maxHp; } }
    public int Hp { get { return hp;} set { hp -= value; } }



    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    protected virtual void Die()
    {
        animator.SetBool("Die", true);
        collider.enabled = false;

        Destroy(gameObject, 3f);
    }

    public virtual void Hit(int damage)
    {
        hp -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Die();
        }
    }
}
