using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Player player;
    public UnityEvent OnStopDash;
    private Vector2 inputDir;
    private Rigidbody2D rb;
    private float maxSpeed;

    private void Start()
    {
        player = GameManager.Player;
        rb = GameManager.Player.rb;
        maxSpeed = 10;
    }

    private void Update()
    {
        if(!player.isDash)
            Move();
        if(rb.velocity.x>maxSpeed)
            rb.velocity =Vector2.right* maxSpeed;
        if(rb.velocity.x<-maxSpeed)
            rb.velocity =Vector2.left* maxSpeed;
        if(rb.velocity.y>maxSpeed)
            rb.velocity =Vector2.up* maxSpeed;
        if(rb.velocity.y<-maxSpeed)
            rb.velocity =Vector2.down* maxSpeed;
    }
    public void Move()
    {
        player.animator.SetInteger("Move",math.abs((int)inputDir.x));
        if (inputDir.x < 0)
            transform.Translate(Vector2.right * inputDir.x* player.movePower *Time.deltaTime);
        else if (inputDir.x > 0 )
            transform.Translate(Vector2.right * inputDir.x * player.movePower * Time.deltaTime);
    }

    public void Jump()
    {
        rb.gravityScale = 1;
        if (player.isDash)
        {
            OnStopDash?.Invoke();
            player.isDash = false;
        }
        if (player.isGround)
        {
            rb.velocity = Vector2.up * player.jumpPower;
            player.animator.SetTrigger("Jump");
        }
        else
        {
            player.animator.SetTrigger("Jump");
            rb.velocity = Vector2.up * player.jumpPower;
            player.doubleJump = false;
        }
    }
    private void OnJump(InputValue value)
    {
        if (player.isGround || player.doubleJump)
            if(!player.isAttack)
                Jump();
    }


   
    private void OnMove(InputValue value)
    {
        if (!player.isDash)
        {
            inputDir = value.Get<Vector2>();
            if (inputDir.x > 0)
            {
                player.rbSprite.flipX = false;

            }
            else if (inputDir.x < 0)
            {
                player.rbSprite.flipX = true;
            }
        }
    }
   
    
}
