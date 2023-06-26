using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSkillB : PlayerSkillAbstract
{
    private void Start()
    {
        GameManager.Player.skillB = this;
        cooltimecheck = true;
        CoolTimeSet();
    }
    public override void CoolTimeSet()
    {
        cooltime = 0.5f;
    }

    public override void Skill()
    {
        if (GameManager.Player.head != null)
        {
            cooltimecheck = false;
            StartCoroutine(CoolTime());
            GameManager.Player.player.position = GameManager.Player.head.position;
            GameManager.Resource.Destroy(GameManager.Player.head.gameObject);
            GameManager.Player.head = null;
        }
    }
}
