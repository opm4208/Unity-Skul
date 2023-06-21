using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TraceMonsterData;

[CreateAssetMenu(fileName = "StandingMonsterData", menuName = "Data/StandingMonster")]
public class StandingMonsterData : ScriptableObject
{
    [SerializeField] StandingMonsterInfo[] standingMonsters;

    public StandingMonsterInfo[] StandingMonsters { get { return standingMonsters; } }
    [Serializable]
    public class StandingMonsterInfo
    {
        public int maxHp;
        public int damage;
        public float attackRange;
        public int coolTime;

    }
}
