using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSkillA : PlayerSkillAbstract
{
    private GameObject head;

    private void Start()
    {
        head = GameManager.Resource.Load<GameObject>("Prefab/Head");
        cooltimecheck = true;
        CoolTimeSet();
        DontDestroyOnLoad(gameObject);
    }
    public override void CoolTimeSet()
    {
        cooltime = 3;
    }

    public override void Skill()
    {
        Debug.Log("ds");
        cooltimecheck = false;
        StartCoroutine(CoolTime());
        GameManager.Player.head = GameManager.Resource.Instantiate(head, GameManager.Player.player.GetChild(1).position, Quaternion.Euler(0, 0, 0), null, true).transform;
        GameManager.Player.animator.SetLayerWeight(1, 1);
    }
}
