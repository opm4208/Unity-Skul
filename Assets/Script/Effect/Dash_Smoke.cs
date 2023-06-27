using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Smoke : MonoBehaviour
{
    private SpriteRenderer spRender;
    private Animator animator;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        spRender = GetComponent<SpriteRenderer>();
        animator.SetTrigger("DashStart");
        if(GameManager.Player.rbSprite.flipX==true)
            spRender.flipX = true;
        else
            spRender.flipX = false;
    }
    private void SmokeRemove()
    {
        GameManager.Resource.Destroy(transform.gameObject);
    }
}
