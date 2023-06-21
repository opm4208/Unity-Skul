using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected int maxHp=20;
    protected int hp;
    protected int damage;
    protected bool attackCT;
    public bool isAttack;
    protected virtual void Awake()
    {
        hp = maxHp;
        damage = 1;
    }
}
