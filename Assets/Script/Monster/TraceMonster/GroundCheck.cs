using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{
    public UnityEvent OnTurned;
    private Vector3 groundCheckPosition;
    private bool change=true;

    private void Awake()
    {
        groundCheckPosition = transform.localPosition;
    }
    public void positionChange()
    {
        if (change)
        {
            transform.localPosition = new Vector3(-groundCheckPosition.x, groundCheckPosition.y, groundCheckPosition.z);
            change = false;
        }
        else
        {
            transform.localPosition = groundCheckPosition;
            change = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTurned?.Invoke();
    }
}
