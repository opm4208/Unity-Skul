using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCountSet : MonoBehaviour
{
    public Transform portal;
    private void Awake()
    {
        GameManager.PortalManager.monsterCount = transform.childCount;
    }
    public void MonsterCheck()
    {
        if(GameManager.PortalManager.monsterCount == 0)
            portal.gameObject.GetComponent<MonsterCount>().MonsterCountGet();
    }
}
