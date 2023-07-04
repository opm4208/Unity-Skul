using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Monster
{
    // Start is called before the first frame update
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
