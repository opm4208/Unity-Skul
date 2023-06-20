using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Range : MonoBehaviour
{
    public LayerMask layerMask;
    public UnityEvent OnEnterTrigger;
    public UnityEvent OnExitTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layerMask.IsContain(collision.gameObject.layer))
        {
            OnEnterTrigger?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (layerMask.IsContain(collision.gameObject.layer))
        {
            OnExitTrigger?.Invoke();
        }
    }
}
