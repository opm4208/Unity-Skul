using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBorn : Head
{

    private void Start()
    {
        sprender = GameManager.Resource.Load<Sprite>("Map/BossClose");
    }
    public class NormalSkillA : PlayerSkillAbstract
    {
        private GameObject head;

        private void Start()
        {
            skillA = this;
            head = GameManager.Resource.Load<GameObject>("Prefab/Head");
            cooltimecheck = true;
            //GameManager.Player.skillA = this;
        }
        public override void CoolTimeSet()
        {
            cooltime = 10;
        }

        public override void Skill()
        {
            cooltimecheck = false;
            StartCoroutine(CoolTime());
            GameManager.Resource.Instantiate(head, GameManager.Player.player.GetChild(1).position, Quaternion.Euler(0, 0, 0), null, true);
        }
    }
}
