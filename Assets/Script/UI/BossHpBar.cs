using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    public HpChanger boss;
    Slider hpbar;

    private void Awake()
    {
        hpbar = GetComponent<Slider>();
    }
    private void Update()
    {
        if (boss.maxHp != 0)
            hpbar.value = (float)boss.hp / (float)boss.maxHp;
    }
}
