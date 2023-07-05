using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Energy_Emerge : Instantiate
{
    protected override void PathName()
    {
        path = "Prefab/Monster/ElderEntP2_EnergyCorps_Projectile_0";
    }

    public void CreatEnergy()
    {
        int i = Random.Range(-20, 20);
        GameManager.Resource.Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, i), null, true);
        GameManager.Resource.Destroy(transform.gameObject);
    }   
}
