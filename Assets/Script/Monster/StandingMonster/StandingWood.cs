using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Wood;

public class StandingWood : StandingMonster
{
    public enum State { Idle, MeleeAttack, RangeAttack, Size }

    public LayerMask playerMask;
    private StateBase[] states; // state를 저장하기 위한 배열
    private State curState;     // 현재 상태
    private Animator anim;
    private CircleCollider2D attackRangeCollider;
    private BoxCollider2D meleeRangeCollider;
    private GameObject standingWoodBall;
    private Transform ballTransform;
    private Vector2 meleeRange;

    private bool isAttack;
    protected override void Awake()
    {
        base.Awake();
        data = GameManager.Resource.Load<StandingMonsterData>("Data/StandingWood");
        standingWoodBall = GameManager.Resource.Load<GameObject>("Prefab/StandingWoodBall");

        maxHp = data.StandingMonsters[0].maxHp;
        hp = maxHp;
        damage = data.StandingMonsters[0].damage;
        attackRange = data.StandingMonsters[0].attackRange;
        coolTime = data.StandingMonsters[0].coolTime;

        states = new StateBase[(int)State.Size];
        states[(int)State.Idle] = new IdleState(this);
        states[(int)State.MeleeAttack] = new MeleeAttackState(this);
        states[(int)State.RangeAttack] = new RangeAttackState(this);
        anim = GetComponent<Animator>();

        meleeRangeCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        attackRangeCollider = transform.GetChild(1).GetComponent<CircleCollider2D>();
        ballTransform = transform.GetChild(2).GetComponent<Transform>();
    }
    private void Start()
    {
        curState = State.Idle;
        states[(int)curState].Enter();
        attackRangeCollider.radius = attackRange;
        meleeRange = new Vector2(meleeRangeCollider.size.x, meleeRangeCollider.size.y);
    }
    private void Update()
    {
        states[(int)curState].Update();
        if (hp < 0)
            Die();
    }
    public void Attack()
    {
        if (curState == State.RangeAttack)
            anim.SetTrigger("Attack");
        else
            anim.SetTrigger("Attack_Melee");
        isAttack = true;
        StartCoroutine(AttackCheck());
    }
    IEnumerator AttackCheck()
    {
        yield return new WaitForSeconds(coolTime);
        isAttack = false;
    }
    public void RangeAttack()
    {
        for(int i=0; i<360; i += 45)
        {
            GameManager.Resource.Instantiate(standingWoodBall, ballTransform.position, Quaternion.Euler(0, 0, i), null, true);
        }
    }
    public void MeleeAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(meleeRangeCollider.transform.position , meleeRange, 0);
        foreach (Collider2D collider in colliders)
        {
            if (playerMask.IsContain(collider.gameObject.layer))
            {
                collider.gameObject.GetComponent<PlayerAttack>().Hit(damage);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(meleeRangeCollider.transform.position, meleeRange);

    }
    public void ChangeState(State state)
    {
        states[(int)curState].Exit();
        curState = state;
        states[(int)curState].Enter();
    }
    public void IdleStateChange()
    {
        ChangeState(State.Idle);
    }
    public void MeleeAttackChange()
    {
        ChangeState(State.MeleeAttack);
    }
    public void RangeAttackChange()
    {
        ChangeState(State.RangeAttack);
    }
 
    public class IdleState : StateBase
    {
        private StandingWood standingWood;
        private float idleTime;

        public IdleState(StandingWood standingWood)
        {
            this.standingWood = standingWood;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {

        }

        public override void Update()
        {
          
        }
    }
    
    public class MeleeAttackState : StateBase
    {
        private StandingWood standingWood;

        public MeleeAttackState(StandingWood standingWood)
        {
            this.standingWood = standingWood;
        }
        public override void Enter()
        {

        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            if(!standingWood.isAttack)
                standingWood.Attack();
        }
    }
    public class RangeAttackState : StateBase
    {
        private StandingWood standingWood;

        public RangeAttackState(StandingWood standingWood)
        {
            this.standingWood = standingWood;
        }
        public override void Enter()
        {

        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            if (!standingWood.isAttack)
                standingWood.Attack();
        }
    }
}
