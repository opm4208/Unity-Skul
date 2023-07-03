using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    protected ElderEnt elderEnt;
    protected Transform stampPosition;
    protected Coroutine stampReady;
    protected Coroutine stamp;
    protected BoxCollider2D boxCollider;
    protected Animator animator;
    protected Vector3 position; 
    protected int damage = 3;
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
            transform.Translate((stampPosition.position - transform.position).normalized * 7 * Time.deltaTime);
            if ((stampPosition.position.y - transform.position.y) < 0.01f)
            {
                Debug.Log("StampReady");
                elderEnt.Stamp();
                StopCoroutine(stampReady);
            }
            yield return null;
        }
    }

    protected IEnumerator Stamp()
    {
        boxCollider.enabled = true;
        Vector3 player = new Vector3(GameManager.Player.transform.position.x, GameManager.Player.transform.position.y - 1);
        while (true)
        {
            Debug.Log("Stamp");
            transform.Translate((player - transform.position).normalized * 10 * Time.deltaTime);
            yield return null;
        }
    }
    public void StampReposition()
    {
        while(true)
        {
            Debug.Log("StampReposition");
            transform.Translate((position - transform.position).normalized * 3 * Time.deltaTime);
            if ((position.y - transform.position.y)+ (position.x - transform.position.x) < 0.01f)
            {
                Debug.Log("true");
                //elderEnt.animator.SetTrigger("Ready");
                animator.SetBool("Stamp", false);
                break;
            }
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
            elderEnt.alone = false;
            StampReadyStart();
            StopCoroutine(stamp);
        }
    }
}
