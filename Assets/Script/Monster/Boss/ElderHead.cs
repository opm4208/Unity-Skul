using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderHead : Monster
{
    ElderEnt elderent;
    public AudioSource hit;
    private void Start()
    {
        elderent = transform.parent.GetComponent<ElderEnt>();
    }
    public override void Hit(int damage)
    {
        hit.Play();
        elderent.Hit(damage);
    }
}
