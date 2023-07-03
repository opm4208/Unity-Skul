using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : Arm
{
    protected void Start()
    {
        base.Start();
        stampPosition = elderEnt.l_StampPosition;
        position = elderEnt.leftReposition;
    }
}
