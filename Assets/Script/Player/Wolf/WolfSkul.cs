using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSkul : MonoBehaviour
{
    public Animator animator;
    public int dashJumpPower=20;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player"&& Input.GetKey(KeyCode.F))
        {
            collision.gameObject.GetComponent<Player>().animator2 = animator;
        }
    }
}
