using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
 
    private Player player;

    private void Start()
    {
        player = GameManager.Player;
    }
    public void Hit(int damage)
    {
        player.hp -= damage;
        Debug.Log(player.hp);
    }
    private void Attack()
    {
        if (!player.attackCT)
        {
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
