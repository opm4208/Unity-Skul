using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int maxHp=20;
    public int hp;
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

    public float dashPower;
    public bool isDash;
    public bool dashCoolTime;
    public int dashCount;

    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer rbSprite;
    public Transform head;  // 리틀본 스킬 A를 위한 변수
    public Transform player;
    public PlayerSkillAbstract skillA;
    public PlayerSkillAbstract skillB;
    public NormalSkillA normalA;
    
    private void Awake()
    {

        hp = maxHp;
        damage = 1;
        dashPower = 3;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
        player = GetComponent<Transform>();
        skillA = GetComponent<NormalSkillA>();
        skillB = GetComponent<NormalSkillB>();
        GameManager.Player = this;
    }

    private void OnSkillA(InputValue value)
    {
        if (skillA.cooltimecheck)
        {
            skillA.Skill();
            skillA.cooltimecheck = false;
        }
    }
    private void OnSkillS(InputValue value)
    {
        if (skillB.cooltimecheck)
            skillB.Skill();
    }
}
