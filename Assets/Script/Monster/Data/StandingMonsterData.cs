using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StandingMonsterData", menuName = "Data/StandingMonster")]
public class StandingMonsterData : ScriptableObject
{
    [SerializeField] StandingMonsterInfo[] standingMonsters;

    [Serializable]
    public class StandingMonsterInfo
    {
        public int maxHp;
        public int damage;
        public float attackRange;
        public int coolTime;

    }
}
