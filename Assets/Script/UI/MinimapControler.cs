using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapControler : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
