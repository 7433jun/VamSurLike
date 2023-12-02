using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterTypeEnum
{
    Slug,
    BrownMushroom,
    BrownStump,
    GreenBush
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
