using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Energy_Charging : MonoBehaviour
{
    public UnityEvent charging;

    public void Charging()
    {
        charging?.Invoke();
    }
    public void DisActive()
    {
        gameObject.SetActive(false);
    }
}
