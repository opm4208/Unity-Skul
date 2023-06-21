using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSet : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
