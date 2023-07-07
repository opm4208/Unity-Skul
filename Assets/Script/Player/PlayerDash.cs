using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    private Coroutine dashRoutine;
    private Coroutine dashCTRoutine;
    private Player player;
    private GameObject dash_Smoke;
    private Transform leftDashStartPoint;
    private Transform rightDashStartPoint;
    private bool dashjump;

    private void Start()
    {
        player = GameManager.Player;
        leftDashStartPoint = player.player.GetChild(2);
        rightDashStartPoint = player.player.GetChild(3);
        dash_Smoke = GameManager.Resource.Load<GameObject>("Prefab/Dash_Smoke_0");
    }

    IEnumerator Dash()
    {
        if (player.rbSprite.flipX == true)
            GameManager.Resource.Instantiate(dash_Smoke, rightDashStartPoint.position, Quaternion.Euler(0, 0, 0), null, true);
        else
            GameManager.Resource.Instantiate(dash_Smoke, leftDashStartPoint.position, Quaternion.Euler(0, 0, 0), null, true);
        DashStart();
        float currentTime = 0f;
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 0.2f)
            {
                player.dashCoolTime = true;
                break;
            }
            if(currentTime>=0.1f)
                dashjump = true;
            if (player.rbSprite.flipX)
            {
                transform.Translate(Vector2.left * player.dashPower * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * player.dashPower * Time.deltaTime);
            }
            if (!dashjump)
            {
                player.rb.AddForce(new Vector2(0, player.dashJumpPower) * Time.deltaTime, ForceMode2D.Impulse);
            }
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
        dashjump = false;
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
