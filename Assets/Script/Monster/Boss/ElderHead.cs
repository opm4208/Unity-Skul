using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderHead : Monster
{
    ElderEnt elderent;

    private void Start()
    {
        elderent = transform.parent.GetComponent<ElderEnt>();
    }
    public override void Hit(int damage)
    {
        elderent.Hit(damage);
    }
}
