using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Wood : TraceMonster
{
    public enum State { Idle, Trace, Attack, patrol, Size }

    public UnityEvent changeRanged;

    public LayerMask playerMask;
    private StateBase[] states; // state를 저장하기 위한 배열
    private State curState;     // 현재 상태
    private Animator anim;
    private BoxCollider2D traceRangeCollider;
    private BoxCollider2D attackRangeCollider;
    private SpriteRenderer render;
    private Coroutine hitRoutine;
    private int hitCount;
    private int DirChange=1;


    public bool right;   // 왼쪽을 보는지 오른쪽을 보는지 확인용
    public bool attackCool;
    public bool hitCheck;

    private void Awake()
    {
        data = GameManager.Resource.Load<TraceMonsterData>("Data/Wood");
        maxHp = data.TraceMonsters[0].maxHp;
        hp = maxHp;
        damage = data.TraceMonsters[0].damage;
        attackRange = data.TraceMonsters[0].attackRange;
        coolTime = data.TraceMonsters[0].coolTime;
        moveSpeed = data.TraceMonsters[0].moveSpeed;
        patrolTime = data.TraceMonsters[0].patrolTime;
        traceRange = data.TraceMonsters[0].traceRange;

        states = new StateBase[(int)State.Size];
        states[(int)State.Idle] = new IdleState(this);
        states[(int)State.Trace] = new TraceState(this);
        states[(int)State.Attack] = new AttackState(this);
        states[(int)State.patrol] = new patrolState(this);

        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        traceRangeCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        attackRangeCollider = transform.GetChild(1).GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        curState = State.Idle;
        states[(int)curState].Enter();
        traceRangeCollider.size =new Vector2( traceRange, 1.5f);
        attackRangeCollider.size = new Vector2(attackRange, 1.5f);
    }

    private void Update()
    {
        states[(int)curState].Update();
    }

    public void ChangeState(State state)
    {
        states[(int)curState].Exit();
        curState = state;
        states[(int)curState].Enter();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, traceRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.GetChild(1).position, attackRange);
    }
    IEnumerator AttackCoolTime()
    {
        yield return new WaitForSeconds(coolTime);
        attackCool = false;
    }

    public void Attack()
    {
        //if (!hitCheck)
        //{
        //    /*anim.SetTrigger("Attack");*/
        //}
        if (!attackCool)
        {
            attackCool = true;
            anim.SetTrigger("Attack");
            StartCoroutine(AttackCoolTime());
        }
    }
    public void AttackRange()
    {
        if (right)
        {
            Vector2 attackPosition = new Vector2(transform.position.x + 1, transform.position.y);
            Vector2 attackBox = new Vector2(attackRange, attackRange);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPosition, attackBox, 0);
            foreach (Collider2D collider in colliders)
            {
                if (playerMask.IsContain(collider.gameObject.layer))
                {
                    collider.gameObject.GetComponent<PlayerAttack>().Hit(damage);
                }
            }
        }
        else
        {
            Vector2 attackPosition = new Vector2(transform.position.x - 1, transform.position.y);
            Vector2 attackBox = new Vector2(attackRange, attackRange);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPosition, attackBox, 0);
            foreach (Collider2D collider in colliders)
            {
                if (playerMask.IsContain(collider.gameObject.layer))
                {
                    collider.gameObject.GetComponent<PlayerAttack>().Hit(damage);
                }
            }
        }
    }
    public override void Hit(int damage)
    {
        if (hitCheck)
            StopCoroutine(hitRoutine);
        anim.SetBool("IsHit", true);
        hitCheck = true;
        hitRoutine = StartCoroutine(HitRoutine());
        
        if(hitCount > 1)
            hitCount = 0;
        hitCount++;
        anim.SetInteger("Hit", hitCount);
        hp -= damage;
    }
    IEnumerator HitRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsHit", false);
        hitCheck = false;
    }
    public void IdleStateChange()
    {
        ChangeState(State.Idle);
    }
    public void TraceStateChange()
    {
        ChangeState(State.Trace);
    }
    public void AttackStateChange()
    {
        ChangeState(State.Attack);
    }
    public void PatrolStateChange()
    {
        ChangeState(State.patrol);
    }

    public void TurnBack()
    {
        if (right)
        {
            right = false;
            render.flipX = true;
            DirChange = 1;
        }
        else
        {
            right = true;
            render.flipX = false;
            DirChange = -1;
        }
        changeRanged?.Invoke();
    }
    public class IdleState : StateBase
    {
        private Wood wood;
        private float idleTime;

        public IdleState(Wood wood)
        {
            this.wood = wood;
        }

        public override void Enter()
        {
            wood.anim.SetBool("Walk", false);
        }

        public override void Exit()
        {

        }

        public override void Update()
        {
            idleTime += Time.deltaTime;
            if (idleTime > 2)
            {
                idleTime = 0;
                wood.ChangeState(State.patrol);
            }
            
        }
    }
    public class TraceState : StateBase
    {
        private Wood wood;

        public TraceState(Wood wood)
        {
            this.wood = wood;
        }
        public override void Enter()
        {
            wood.anim.SetBool("Walk", true);
        }

        public override void Exit()
        {
            wood.anim.SetBool("Walk", false);
        }

        public override void Update()
        {
            Vector2 dir = (GameManager.Player.position- wood.transform.position).normalized;
            if (dir.x <= 0)
            {
                if (wood.right)
                    wood.TurnBack();
                wood.right = false;
            }
            else
            {
                if (!wood.right)
                    wood.TurnBack();
                wood.right = true;
            }
            wood.transform.Translate(wood.moveSpeed * new Vector2(dir.x,0) * Time.deltaTime);
        }
    }
    public class AttackState : StateBase
    {
        private Wood wood;

        public AttackState(Wood wood)
        {
            this.wood = wood;
        }
        public override void Enter()
        {
            
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            if (!wood.attackCool)
            {
                wood.Attack();
            }
        }
    }
    public class patrolState : StateBase
    {
        private float patrolTime;
        private Wood wood;

        public patrolState(Wood wood)
        {
            this.wood = wood;
        }
        public override void Enter()
        {
            wood.anim.SetBool("Walk", true);
        }

        public override void Exit()
        {
            wood.anim.SetBool("Walk", false);
        }

        public override void Update()
        {
            patrolTime += Time.deltaTime;
            if (patrolTime > 5)
            {
                patrolTime = 0;
                wood.ChangeState(State.Idle);
            }
            wood.transform.Translate(wood.moveSpeed * Vector2.left * wood.DirChange * Time.deltaTime);
        }
    }
}