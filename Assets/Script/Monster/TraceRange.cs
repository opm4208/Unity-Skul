using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TraceRange : MonoBehaviour
{
    public LayerMask playerMask;
    public UnityEvent OnTraced;
    public UnityEvent OnIdled;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMask.IsContain(collision.gameObject.layer))
        {
            OnTraced?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerMask.IsContain(collision.gameObject.layer))
        {
            OnIdled?.Invoke();
        }
    }
}
