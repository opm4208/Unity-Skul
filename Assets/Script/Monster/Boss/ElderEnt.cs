using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderEnt : MonoBehaviour
{

    private void SetAnimatorRecursively(Transform trans)
    {
        Animator animator = trans.GetComponent<Animator>();
        foreach (Transform child in trans)
        {
            SetAnimatorRecursively(child);
        }
    }
}
