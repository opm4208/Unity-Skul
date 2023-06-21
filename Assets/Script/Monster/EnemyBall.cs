using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    public LayerMask layerMask;
    protected int damage;

    protected virtual void Update()
    {
        transform.Translate(Vector2.right*1*Time.deltaTime);
    }

    
}
