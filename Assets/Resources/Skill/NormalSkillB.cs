using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSkillB : PlayerSkillAbstract
{
    private void Start()
    {
        GameManager.Player.skillB = this;
        cooltimecheck = true;
    }
    public override void CoolTimeSet()
    {
        cooltime = 0;
    }

    public override void Skill()
    {
        cooltimecheck = false;
        StartCoroutine(CoolTime());
        GameManager.Player.player.position = GameManager.Player.head.position;
    }
}
