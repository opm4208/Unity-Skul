using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpChanger : MonoBehaviour
{
    public Monster monster;
    public int hp;
    public int maxHp;
    private void Update()
    {
        hp = monster.Hp;
        maxHp = monster.MaxHp;
    }
}
