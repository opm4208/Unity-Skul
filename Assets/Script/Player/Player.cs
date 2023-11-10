using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float maxHp=20;
    public float hp;
    public int damage;
    public float movePower;
    public float maxSpeed;

    public LayerMask monsterMask;
    public bool isAttack;
    public bool attackCT;
    public int attackCombo = 0;
    public int maxAttackCombo=2;

    public float jumpPower;
    public bool isGround;
    public bool doubleJump;

    public int dashJumpPower;
    public float dashPower;
    public bool isDash;
    public bool dashCoolTime;
    public int dashCount;

    public bool change;

    public Animator animator;
    public Animator animator2;
    public Animator chanimator;
    public Rigidbody2D rb;
    public SpriteRenderer rbSprite;
    public Transform head;  // 리틀본 스킬 A를 위한 변수
    public Transform player;
    public PlayerSkillAbstract skillA;
    public PlayerSkillAbstract skillB;
    public PlayerSkillAbstract chSkillA;
    public PlayerSkillAbstract chSkillB;

    public AudioSource jump;
    public AudioSource jumpAttack;
    public AudioSource hit;
    public AudioSource attack1;
    public AudioSource attack2;
    private void Awake()
    {
        hp = maxHp;
        damage = 10;
        dashPower = 10f; // wolf=15;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
        player = GetComponent<Transform>();
        dashJumpPower = 20; // wolf=20;
        GameManager.Player = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Change()
    {
        transform.position += new Vector3(0, 0, 0.1f);
        if(change)
            change = false;
        else
            change = true;
        if(change)
        {
            animator.runtimeAnimatorController = chanimator.runtimeAnimatorController;
            dashPower = 15;
        }
        else
        {
            animator.runtimeAnimatorController = animator2.runtimeAnimatorController;
            dashPower = 10;
        }
    }
    private void OnChange(InputValue value)
    {
        GameManager.Pool.canvasRoot.GetComponent<UiControler>().TempImage();
        Change();
    }
    private void OnSkillA(InputValue value)
    {
        if(change)
        {
            if (chSkillA.cooltimecheck)
            {
                chSkillA.Skill();
                animator.SetTrigger("SkillA");
            }
        }
        else
        {
            if (skillA.cooltimecheck)
            {
                skillA.Skill();
            }
        }
    }
    IEnumerator SkiilB()
    {
        yield return new WaitForSeconds(0.5f);
        chSkillB.Skill();
    }
    private void OnSkillS(InputValue value)
    {
        if (change)
        {
            if (chSkillB.cooltimecheck)
            {
                StartCoroutine(SkiilB());
                animator.SetTrigger("SkillB");
            }
        }
        else
        {
            if (skillB.cooltimecheck)
                skillB.Skill();
        }
    }
}
