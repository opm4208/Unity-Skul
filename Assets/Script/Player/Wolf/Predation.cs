using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predation : MonoBehaviour
{
    public void PredationAttack()
    {
        Vector2 attackBox = new Vector2(3.5f, 3f);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), attackBox, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "Monster")
            {
                Debug.Log("A");
                collider.gameObject.GetComponent<Monster>().Hit(20);
            }
        }
    }
}
