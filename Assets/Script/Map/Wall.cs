using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Monster
{
    void Start()
    {
        maxHp = 20;
        hp = 20;
    }

    public override void Hit(int damage)
    {
        base.Hit(damage);
        if (hp < 1)
            Destroy(gameObject);
    }
}
