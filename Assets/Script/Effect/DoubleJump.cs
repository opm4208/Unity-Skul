using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private Animator animator;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("DoubleJump");
    }
    private void SmokeRemove()
    {
        GameManager.Resource.Destroy(transform.gameObject);
    }
}
