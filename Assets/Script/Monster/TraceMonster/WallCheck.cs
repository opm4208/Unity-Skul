using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallCheck : MonoBehaviour
{
    public UnityEvent OnTurned;
    private Vector3 wallCheckPosition;
    private bool change = true;

    private void Awake()
    {
        wallCheckPosition = transform.localPosition;
    }

    public void positionChange()
    {
        if (change)
        {
            transform.localPosition = new Vector3(-wallCheckPosition.x, wallCheckPosition.y, wallCheckPosition.z);
            change = false;
        }
        else
        {
            transform.localPosition = wallCheckPosition;
            change = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTurned?.Invoke();
    }
}
