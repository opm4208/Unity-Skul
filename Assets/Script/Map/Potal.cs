using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    Transform f;

    private void Start()
    {
        f = transform.GetChild(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        f.gameObject.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        f.gameObject.SetActive(false);
    }
}
