using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterTypeEnum
{
    Normal1,
    Normal2,
    Normal3,
    Normal4,
    Pattern1,
    Pattern2,
    Pattern3,
    Pattern4,
    Pattern5,
    Pattern6,
    MiddleBoss1,
    MiddleBoss2,
    MiddleBoss3,
    LastBoss
}

public class FactoryManager : MonoBehaviour
{
    [SerializeField] List<GameObject> monsterList;

    public GameObject GetMonster(MonsterTypeEnum monsterType)
    {
        GameObject monster = null;

        if ((int)monsterType < monsterList.Count)
        {
            monster = monsterList[(int)monsterType];
        }
        else
        {
            Debug.LogError($"Monster type {monsterType} not found in the list.");
        }

        return monster;
    }
}
