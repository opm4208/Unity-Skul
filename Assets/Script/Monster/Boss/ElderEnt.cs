using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElderEnt : Monster
{
    public new Animator animator;
    public Transform l_StampPosition;
    public Transform R_StampPosition;
    public Transform ChargingPosition;
    public Transform SparkPosition;
    public Transform HpUi;
    public Transform HpChUi;
    public LeftArm leftArm;
    public RightArm rightArm;
    public Vector3 leftReposition;
    public Vector3 rightReposition;
    public int stampCount=0;
    public int attackPattern;
    protected int pattern = 1;
    public GameObject ElderCh;
    public HpChanger hpChanger;

    protected bool change = false;
    public bool right; //오른손 왼손 구별

    private new void Awake()
    {
        animator = GetComponent<Animator>();
        l_StampPosition = transform.GetChild(6);
        R_StampPosition = transform.GetChild(5);
        leftArm = transform.GetChild(3).GetChild(0).GetComponent<LeftArm>();
        rightArm = transform.GetChild(4).GetChild(0).GetComponent<RightArm>();
        leftReposition = transform.GetChild(3).GetChild(0).position;
        rightReposition = transform.GetChild(4).GetChild(0).position;
        ChargingPosition = transform.GetChild(1).GetChild(0).transform;
        SparkPosition = transform.GetChild(1).GetChild(1).transform;
    }
    private void Start()
    {
        animator.SetTrigger("Ready");
        maxHp = 50;
        hp = maxHp;
        //attackPattern = 2;
    }
    public void StopAnimator()
    {
        animator.SetBool("Salm", false);
        animator.SetBool("Stamp", false);
        animator.SetBool("StampReposition", false);
        animator.SetBool("Energy", false);
    }
    public void SparkSetactive()
    {
        SparkPosition.gameObject.SetActive(true);
    }
    IEnumerator EnergyEnd()
    {
        yield return new WaitForSeconds(15);
        SparkPosition.gameObject.SetActive(false);
        animator.SetBool("Energy", false);
        leftArm.animator.SetBool("Energy", false);
        rightArm.animator.SetBool("Energy", false);
        animator.SetTrigger("Ready");
    }
    private bool Decision()
    {
        // 플레이어의 위치가 기준보다 오른쪽이면 true 아니면 false
        return transform.position.x- GameManager.Player.player.position.x<0 ? true : false; 
    }
    public void Stamp()
    {
        rightArm.ReadyStop();
        leftArm.ReadyStop();
        if (stampCount > 1)
        {
            animator.SetBool("StampReady", false);
            rightArm.StampReposition();
            leftArm.StampReposition();
        }
        else
        {
            animator.SetBool("Stamp", true);
            if (Decision())
            {
                rightArm.StampStart();
                right = true;
            }
            else
            {
                leftArm.StampStart();
                right = false;
            }
        }
    }
    public void StampReady()
    {
        animator.SetBool("Stamp", false);
        if (right)
            rightArm.StampReadyStart();
        else
            leftArm.StampReadyStart();
    }
    public void StartReady()
    {
        animator.SetBool("Slam", false);
        animator.SetBool("Ready", true);
    }
    public void SlamStop()
    {
        animator.SetBool("Slam", false);
        rightArm.animator.SetBool("Slam", false);
        leftArm.animator.SetBool("Slam", false);
    }
    public void AttackPattern()
    {
        // stamp 패턴
        if(attackPattern==0)
        {
            animator.SetBool("StampReady", true);
            stampCount = 0;
            leftArm.StampReadyStart();
            rightArm.StampReadyStart();
        }
        // slam 패턴
        if(attackPattern==1)
        {
            animator.SetBool("Slam",true);
            rightArm.animator.SetBool("Slam", true);
            leftArm.animator.SetBool("Slam",true );
        }
        // energy 패턴
        if(attackPattern==2)
        {
            StartCoroutine(EnergyEnd());
            animator.SetBool("Energy", true);
            leftArm.animator.SetBool("Energy", true);
            rightArm.animator.SetBool("Energy", true);
            ChargingPosition.gameObject.SetActive(true);
        }
        attackPattern++;
        if (attackPattern > pattern)
            attackPattern = 0;
    }
    protected override void Die()
    {
        // 1페이즈
        if (!change)
        {
            //HpUi.gameObject.SetActive(false);
            ElderCh.gameObject.SetActive(true);
            hpChanger.monster = ElderCh.GetComponent<Monster>();
            gameObject.SetActive(false);
        }
        else
        {
            StopAnimator();
            animator.SetBool("Die", true);
            leftArm.animator.SetBool("Energy", true);
            rightArm.animator.SetBool("Energy", true);
            ElderCh.SetActive(false);
            //Destroy(gameObject, 3f);
        }
    }
    public override void Hit(int damage)
    {
        base.Hit(damage);
    }
}
