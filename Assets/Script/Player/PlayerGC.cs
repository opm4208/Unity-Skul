using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerGC : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GameManager.Player;
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
