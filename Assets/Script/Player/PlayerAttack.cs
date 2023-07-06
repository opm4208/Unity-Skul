using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
 
    private Player player;
    private bool invincibility;
    private GameObject hitImpact;
    private void Start()
    {
        player = GameManager.Player;
        hitImpact = GameManager.Resource.Load<GameObject>("Prefab/Hit_Skul");
    }
    public void Hit(int damage)
    {
        if (!invincibility)
        {
            player.hit.Play();
            player.rbSprite.color = new Color(1, 1, 1, 0.5f);
            invincibility = true;
            player.hp -= damage;
            StartCoroutine(Invincibility());
            Debug.Log(player.hp);
        }
    }
    IEnumerator Invincibility()
    {
        yield return new WaitForSeconds(0.5f);
        player.rbSprite.color = new Color(1, 1, 1, 1);
        invincibility = false;
    }
    private void Attack()
    {
        if (!player.attackCT)
        {
            if(!player.isGround)
                player.jumpAttack.Play();
            else if(player.attackCombo==1)
                player.attack1.Play();
            else if(player.attackCombo==2)
                player.attack2.Play();
            if (player.attackCombo > 1)
                player.attackCombo = 0;
            player.attackCombo++;
            player.isAttack = true;
            player.animator.SetInteger("AttackCount", player.attackCombo);
            player.animator.SetTrigger("Attack");
            player.attackCT = true;
            StartCoroutine(AttackCT());
            AttackRange();
        }   
    }
    private void OnAttack(InputValue value)
    {
        Attack();
    }
    private void AttackRange()
    {
        // ¿À¸¥ÂÊ
        if (!player.rbSprite.flipX)
        {
            Vector2 attackPosition = new Vector2(transform.position.x + 0.4f, transform.position.y);
            Vector2 attackBox = new Vector2(1.5f, 1);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPosition, attackBox, 0);
            foreach (Collider2D collider in colliders)
            {
                if (player.monsterMask.IsContain(collider.gameObject.layer))
                {
                    collider.gameObject.GetComponent<Monster>().Hit(player.damage);
                    GameManager.Resource.Instantiate(hitImpact, new Vector2(0.5f + collider.transform.position.x, collider.transform.position.y), Quaternion.Euler(0, 0, 0), null, true);
                }
            }
        }
        else
        {
            Vector2 attackPosition = new Vector2(transform.position.x - 0.4f, transform.position.y);
            Vector2 attackBox = new Vector2(1.5f, 1);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPosition, attackBox, 0);
            foreach (Collider2D collider in colliders)
            {
                if (player.monsterMask.IsContain(collider.gameObject.layer))
                {
                    collider.gameObject.GetComponent<Monster>().Hit(player.damage);
                    GameManager.Resource.Instantiate(hitImpact,new Vector2(-0.5f+collider.transform.position.x,collider.transform.position.y), Quaternion.Euler(0, 0, 180), null, true);
                }
            }
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireCube(new Vector2(transform.position.x + 0.4f, transform.position.y), new Vector2(1.5f, 1));
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(new Vector2(transform.position.x - 0.4f, transform.position.y), new Vector2(1.5f, 1));
    //}
    IEnumerator AttackCT()
    {
        yield return new WaitForSeconds(0.3f);
        player.isAttack = false;
        player.attackCT = false;
    }

}
