using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected int maxHp=20;
    protected int hp;
    protected int damage;
    private void Awake()
    {
        hp = maxHp;
    }
}
