using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraceMonsterData", menuName = "Data/TraceMonster")]
public class TraceMonsterData : ScriptableObject
{
    [SerializeField] TraceMonsterInfo[] traceMonsters;

    public TraceMonsterInfo[] TraceMonsters { get { return traceMonsters; } }

    [Serializable]
    public class TraceMonsterInfo
    {
        public int maxHp;
        public int damage;
        public float attackRange;
        public int coolTime;
        public int moveSpeed;
        public int patrolTime;
        public float traceRange;
    }
}

