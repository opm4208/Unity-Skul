using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGC : MonoBehaviour
{
    public Animator animator;
    public bool isGround;
    public bool doubleJump;


    private void Start()
    {
        animator = GameManager.Player.animator;
        isGround = GameManager.Player.isGround;
        doubleJump = GameManager.Player.doubleJump;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGround = true;
        doubleJump = true;
        animator.SetBool("GroundCheck", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false;
        animator.SetBool("GroundCheck", false);
    }
}
