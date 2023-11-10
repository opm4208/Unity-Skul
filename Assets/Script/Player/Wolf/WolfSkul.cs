using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSkul : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Animator animator;
    public int dashJumpPower=20;
    public PlayerSkillAbstract skillA;
    public PlayerSkillAbstract skillB;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.F))
        {
            sprite.enabled = false;
            collision.gameObject.GetComponent<Player>().chanimator = animator;
            collision.gameObject.GetComponent<Player>().dashJumpPower = dashJumpPower;
            collision.gameObject.GetComponent<Player>().chSkillA = skillA;
            collision.gameObject.GetComponent<Player>().chSkillB = skillB;
            transform.parent = collision.transform;
            GameManager.Player.Change();
            GameManager.Pool.canvasRoot.GetComponent<UiControler>().GetSkul();
        }
    }
}
