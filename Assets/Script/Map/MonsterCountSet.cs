using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCountSet : MonoBehaviour
{
    void Start()
    {
        GameManager.PortalManager.monsterCount = transform.childCount;
    }
}
