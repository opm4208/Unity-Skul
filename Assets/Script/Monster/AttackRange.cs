using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public UnityEvent OnAttacked;
    public UnityEvent OnTraced;

    private Vector3 attackRangePosition;
    private bool change = true;
    private void Awake()
    {
        attackRangePosition = transform.localPosition;
    }
    public void positionChange()
    {
        if (change)
        {
            transform.localPosition = new Vector3(-attackRangePosition.x, attackRangePosition.y, attackRangePosition.z);
            change = false;
        }
        else
        {
            transform.localPosition = attackRangePosition;
            change = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnAttacked?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTraced?.Invoke();
    }

}
