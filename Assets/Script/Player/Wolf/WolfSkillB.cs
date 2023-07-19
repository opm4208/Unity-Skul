using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSkillB : PlayerSkillAbstract
{
    private GameObject Ripper;
    private Player player;
    private void Awake()
    {
        Ripper = GameManager.Resource.Load<GameObject>("Skill/Werewolf_4_Ripper_0");
        player = GameManager.Player;
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
        
        Vector2 attackBox = new Vector2(8f, 1);
        if (!GameManager.Player.rbSprite.flipX)
        {
            Vector2 attackPosition = new Vector2(transform.position.x + 4f, transform.position.y);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPosition, attackBox, 0);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.tag == "Monster")
                {
                    Debug.Log("B");
                    GameManager.Resource.Instantiate(Ripper,collider.transform.position, Quaternion.Euler(0, 0, 0), null, true);
                    collider.gameObject.GetComponent<Monster>().Hit(20);
                }
            }
            player.transform.Translate(Vector2.right * 8);
        }
        else
        {
            Vector2 attackPosition = new Vector2(transform.position.x + 4f, transform.position.y);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPosition, attackBox, 0);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.tag == "Monster")
                {
                    GameManager.Resource.Instantiate(Ripper, collider.transform.position, Quaternion.Euler(0, 180, 0), null, true);
                    collider.gameObject.GetComponent<Monster>().Hit(20);
                }
            }
            player.transform.Translate(Vector2.left * 8);
        }
    }
}
