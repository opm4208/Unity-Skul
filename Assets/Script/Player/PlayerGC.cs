using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGC : MonoBehaviour
{
    private PlayerMove player;
    private void Awake()
    {
        player = GetComponentInParent<PlayerMove>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.isGround = true;
        player.doubleJump = true;
        player.animator.SetBool("GroundCheck", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.isGround = false;
        player.animator.SetBool("GroundCheck", false);
    }
}
