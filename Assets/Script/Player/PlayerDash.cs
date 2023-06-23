using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    private Coroutine dashRoutine;
    private Coroutine dashCTRoutine;
    private Player player;


    private void Start()
    {
        player = GameManager.Player;
    }

    IEnumerator Dash()
    {
        DashStart();
        float currentTime = 0f;
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 0.5f)
            {
                player.dashCoolTime = true;
                break;
            }
            if (player.rbSprite.flipX)
                transform.Translate(Vector2.left * player.dashPower * Time.deltaTime);
            else
                transform.Translate(Vector2.right * player.dashPower * Time.deltaTime);
            yield return null;
        }
        DashEnd();
    }

    IEnumerator DashCoolTime()
    {
        yield return new WaitForSeconds(1f);
        player.dashCount = 0;
        player.dashCoolTime = false;
    }
    private void OnDash(InputValue value)
    {
        if (player.dashCount < 2 && !player.isAttack)
        {
            if (player.dashCount == 1)
                StopCoroutine(dashCTRoutine);
            dashRoutine = StartCoroutine(Dash());
        }
    }
    public void StopDash()
    {
        StopCoroutine(dashRoutine);
    }
    private void DashEnd()
    {
        player.rb.gravityScale = 1;
        player.isDash = false;
    }
    private void DashStart()
    {
        dashCTRoutine = StartCoroutine(DashCoolTime());
        player.dashCount++;
        player.rb.gravityScale = 0;
        player.rb.velocity = Vector2.up * 0;
        player.isDash = true;
        player.animator.SetTrigger("Dash");
    }
}
