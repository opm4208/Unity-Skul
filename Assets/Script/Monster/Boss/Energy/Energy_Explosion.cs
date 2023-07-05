using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Explosion : MonoBehaviour
{
    public void Destroy()
    {
        GameManager.Resource.Destroy(gameObject);
    }
}
