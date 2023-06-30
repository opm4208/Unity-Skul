using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : Arm
{
    protected void Start()
    {
        base.Start();
        stampPosition = elderEnt.R_StampPosition;
        stampReady = StartCoroutine(StampReady());
    }
}
