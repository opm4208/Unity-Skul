using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderEntChange : ElderEnt
{
    

    private void OnEnable()
    {
        pattern = 2;
        change = true;
    }
    public Monster This()
    {
        return this;
    }
}
