using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCount : MonoBehaviour
{
    private void Start()
    {
        MonsterCountGet();
    }
    public void MonsterCountGet()
    {
        if (GameManager.PortalManager.monsterCount == 0)
        {
            gameObject.AddComponent<Potal>();
        }
    }
}
