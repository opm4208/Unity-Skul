using System;
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

    public int MaxHp { get { return maxHp; } set { maxHp = value; } }
    public int Hp { get { return hp;} set { hp -= value; } }



    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    protected virtual void Die()
    {
        //animator.SetTrigger("Die");
        Destroy(gameObject, 3f);
    }

    private void SetLayersRecursively(Transform trans)
    {
        trans.gameObject.layer = 10;
        foreach(Transform child in trans)
        {
            SetLayersRecursively(child);
        }
    }

    public virtual void Hit(int damage)
    {
        hp -= damage;
        if(hp<1)
            Die();
        Debug.Log(hp);
    }

}
