using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_List : Instantiate
{
    public void ListSet()
    {
        StartCoroutine(ListSeted());
    }
    IEnumerator ListSeted()
    {
        foreach(Transform child in transform)
        {
            Debug.Log(prefab);
            yield return new WaitForSeconds(0.5f);
            GameManager.Resource.Instantiate(prefab, child.position, Quaternion.Euler(0, 0, 0), null, true);
        }
    }
    protected override void PathName()
    {
        path = "Prefab/Monster/ElderEntP2_EnergyCorps_Projectile_Emerge_0";
    }
}
