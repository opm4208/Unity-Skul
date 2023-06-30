using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElderEnt : MonoBehaviour
{
    public Transform l_StampPosition;
    public Transform R_StampPosition;
    public bool decision;

    private void Awake()
    {
        l_StampPosition = transform.GetChild(6);
        R_StampPosition = transform.GetChild(5);
    }

    private void Decision()
    {
        // 플레이어의 위치가 기준보다 오른쪽이면 true 아니면 false
        decision =  transform.position.x- GameManager.Player.player.position.x<0 ? true : false; 
    }
    private void SetAnimatorRecursively(Transform trans)
    {
        Animator animator = trans.GetComponent<Animator>();
        foreach (Transform child in trans)
        {
            SetAnimatorRecursively(child);
        }
    }
}
