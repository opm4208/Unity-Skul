using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Arm : MonoBehaviour
{
    protected ElderEnt elderEnt;
    protected Transform stampPosition;
    protected Coroutine stampReady;
    protected Coroutine stamp;
    protected Coroutine reposition;
    protected BoxCollider2D boxCollider;
    public Animator animator;
    protected Vector3 position; 
    protected int damage = 3;
    public bool right; // 왼손 오른손 구분
    protected void Start()
    {
        elderEnt = transform.parent.parent.GetComponent<ElderEnt>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    protected IEnumerator StampReady()
    {
        while (true)
        {
            transform.Translate((stampPosition.position - transform.position).normalized * 10 * Time.deltaTime);
            if ((stampPosition.position.y - transform.position.y) < 0.01f)
            {
                elderEnt.Stamp();
            }
            yield return null;
        }
    }
    public void ReadyStop()
    {
        StopCoroutine(stampReady);
    }
    protected IEnumerator Stamp()
    {
        boxCollider.enabled = true;
        Vector3 player = new Vector3(GameManager.Player.transform.position.x, GameManager.Player.transform.position.y - 10);
        while (true)
        {
            transform.Translate((player - transform.position).normalized * 13 * Time.deltaTime);
            yield return null;
        }
    }
    public void StampReposition()
    {
        reposition = StartCoroutine(Reposition());
    }
    IEnumerator Reposition()
    {
        while (true)
        {
            transform.Translate((position - transform.position).normalized *5 * Time.deltaTime);
            if (math.abs(position.y - transform.position.y) < 0.01f)
            {
                if(right)
                    elderEnt.animator.SetTrigger("Ready");
                animator.SetBool("Stamp", false);
                StopCoroutine(reposition);
            }
            yield return null;
        }
    }
    public void StampReadyStart()
    {
        animator.SetBool("Stamp", true);
        stampReady = StartCoroutine(StampReady());
    }
    public void StampStart()
    {
        stamp = StartCoroutine(Stamp());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<PlayerAttack>().Hit(damage);
        }
        if (collision.gameObject.tag == "Ground")
        {
            elderEnt.stampCount++;
            boxCollider.enabled = false;
            elderEnt.StampReady();
            StopCoroutine(stamp);
        }
    }
}
