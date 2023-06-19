using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player
{
    public void Hit(int damage)
    {
        hp -= damage;
    }

}
