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
    private BoxCollider2D rangeAttackCollider;
    private BoxCollider2D meleeAttackCollider;
    private void Awake()
    {
        states = new StateBase[(int)State.Size];
        states[(int)State.Idle] = new IdleState(this);
        states[(int)State.MeleeAttack] = new MeleeAttackState(this);
        states[(int)State.RangeAttack] = new RangeAttackState(this);
    }
    public class IdleState : StateBase
    {
        private StandingWood wood;
        private float idleTime;

        public IdleState(StandingWood wood)
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
          
        }
    }
    
    public class MeleeAttackState : StateBase
    {
        private StandingWood wood;

        public MeleeAttackState(StandingWood wood)
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

        }
    }
    public class RangeAttackState : StateBase
    {
        private StandingWood wood;

        public RangeAttackState(StandingWood wood)
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

        }
    }
}
