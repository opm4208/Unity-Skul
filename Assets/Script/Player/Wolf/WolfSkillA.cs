using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSkillA : PlayerSkillAbstract
{
    private GameObject Predation;
    private void Awake()
    {
        Predation = GameManager.Resource.Load<GameObject>("Skill/Werewolf_4_Predation_0");
    }
    private void Start()
    {
        cooltimecheck = true;
        CoolTimeSet();
    }
    public override void CoolTimeSet()
    {
        cooltime = 3f;
    }

    public override void Skill()
    {
        GameObject predation = GameManager.Resource.Instantiate<GameObject>(Predation, transform);
        if (!GameManager.Player.rbSprite.flipX)
        {
            predation.transform.position  = new Vector2(transform.position.x + 1, transform.position.y);
        }
        else
        {
            predation.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            SpriteRenderer predationsp = predation.GetComponent<SpriteRenderer>();
            predationsp.flipX = true;
        }
    }
}
