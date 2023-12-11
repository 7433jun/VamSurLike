using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] FactoryManager factoryManager;
    [SerializeField] Transform myCamera;
    [SerializeField] float radius;

    public static MonsterTypeEnum normalMonster;

    void Start()
    {
        normalMonster = MonsterTypeEnum.Normal1;

        StartCoroutine(NormalSpawn());
        StartCoroutine(Pattern1Spawn());
        StartCoroutine(Pattern2Spawn());
        StartCoroutine(MiddleBoss1Spawn());
        StartCoroutine(Pattern3Spawn());
        StartCoroutine(Pattern4Spawn());
        StartCoroutine(MiddleBoss2Spawn());
        StartCoroutine(Pattern5Spawn());
        StartCoroutine(Pattern6Spawn());
        StartCoroutine(MiddleBoss3Spawn());
        StartCoroutine(LastBossSpawn());
    }

    IEnumerator NormalSpawn()
    {
        while (true)
        {
            if (myCamera != null)
            {
                float randomAngle = Random.Range(0f, 360f);

                // 각도를 라디안으로 변환
                float radian = Mathf.Deg2Rad * randomAngle;

                // 새로운 위치 계산
                float x = myCamera.position.x + Mathf.Sin(radian) * radius;
                float y = myCamera.position.y + Mathf.Cos(radian) * radius;

                // 새로운 위치 설정
                //transform.position = new Vector3(x, y, 0f);

                Instantiate(factoryManager.GetMonster(normalMonster), new Vector3(x, y, 0f), Quaternion.identity);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Pattern1Spawn()
    {
        yield return new WaitForSeconds(60f);

        for(float angle = 0f; angle < 360f; angle += 10f)
        {
            float radian = Mathf.Deg2Rad * angle;

            float x = myCamera.position.x + Mathf.Sin(radian) * 12;
            float y = myCamera.position.y + Mathf.Cos(radian) * 12;

            Instantiate(factoryManager.GetMonster(MonsterTypeEnum.Pattern1), new Vector3(x, y, 0f), Quaternion.identity);
        }
    }

    IEnumerator Pattern2Spawn()
    {
        yield return new WaitForSeconds(120f);

        for(int i = 0; i < 6; i++)
        {
            float randomAngle = Random.Range(0f, 360f);

            float radian = Mathf.Deg2Rad * randomAngle;

            float x = myCamera.position.x + Mathf.Sin(radian) * 12;
            float y = myCamera.position.y + Mathf.Cos(radian) * 12;

            for(int j = 0; j < 20; j++)
            {
                Instantiate(factoryManager.GetMonster(MonsterTypeEnum.Pattern2), new Vector3(x + Random.Range(-0.1f, 0.1f), y + Random.Range(-0.1f, 0.1f), 0f), Quaternion.identity);
            }

            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator MiddleBoss1Spawn()
    {
        yield return new WaitForSeconds(180f);

        float randomAngle = Random.Range(0f, 360f);

        float radian = Mathf.Deg2Rad * randomAngle;

        float x = myCamera.position.x + Mathf.Sin(radian) * 10;
        float y = myCamera.position.y + Mathf.Cos(radian) * 10;

        Instantiate(factoryManager.GetMonster(MonsterTypeEnum.MiddleBoss1), new Vector3(x, y, 0f), Quaternion.identity);
    }

    IEnumerator Pattern3Spawn()
    {
        yield return new WaitForSeconds(240f);

        for (int i = 0; i < 6; i++)
        {
            for (float angle = 0f; angle < 360f; angle += 45f)
            {
                float radian = Mathf.Deg2Rad * angle;

                float x = myCamera.position.x + Mathf.Sin(radian) * 12;
                float y = myCamera.position.y + Mathf.Cos(radian) * 12;

                Instantiate(factoryManager.GetMonster(MonsterTypeEnum.Pattern3), new Vector3(x, y, 0f), Quaternion.identity);
            }
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator Pattern4Spawn()
    {
        yield return new WaitForSeconds(300f);

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Monster monster = Instantiate(factoryManager.GetMonster(MonsterTypeEnum.Pattern4), new Vector3(17f, -6f + j * 3f, 0f), Quaternion.identity).GetComponent<Monster>();

                monster.direction = new Vector2(-1, 0);
            }

            yield return new WaitForSeconds(5f);

            for (int j = 0;j < 9; j++)
            {
                Monster monster = Instantiate(factoryManager.GetMonster(MonsterTypeEnum.Pattern4), new Vector3(-12f + j * 3f, -11f, 0f), Quaternion.identity).GetComponent<Monster>();

                monster.direction = new Vector2(0, 1);
            }

            yield return new WaitForSeconds(5f);

            for (int j = 0; j < 5; j++)
            {
                Monster monster = Instantiate(factoryManager.GetMonster(MonsterTypeEnum.Pattern4), new Vector3(-17f, -6f + j * 3f, 0f), Quaternion.identity).GetComponent<Monster>();

                monster.direction = new Vector2(1, 0);
            }

            yield return new WaitForSeconds(5f);

            for (int j = 0; j < 9; j++)
            {
                Monster monster = Instantiate(factoryManager.GetMonster(MonsterTypeEnum.Pattern4), new Vector3(-12f + j * 3f, 11f, 0f), Quaternion.identity).GetComponent<Monster>();

                monster.direction = new Vector2(0, -1);
            }

            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator MiddleBoss2Spawn()
    {
        yield return new WaitForSeconds(360f);

        float randomAngle = Random.Range(0f, 360f);

        float radian = Mathf.Deg2Rad * randomAngle;

        float x = myCamera.position.x + Mathf.Sin(radian) * 10;
        float y = myCamera.position.y + Mathf.Cos(radian) * 10;

        Instantiate(factoryManager.GetMonster(MonsterTypeEnum.MiddleBoss2), new Vector3(x, y, 0f), Quaternion.identity);
    }

    IEnumerator Pattern5Spawn()
    {
        yield return new WaitForSeconds(420f);

        GameObject warningCircle = Resources.Load<GameObject>("Warning Circle");
        Transform playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        for (int i = 0; i < 20; i++)
        {
            Vector2 spawnPosition = playerTransform.position;

            Instantiate(warningCircle, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(0.9f);

            Instantiate(factoryManager.GetMonster(MonsterTypeEnum.Pattern5), spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(1.1f);
        }
    }

    IEnumerator Pattern6Spawn()
    {
        yield return new WaitForSeconds(480f);

        GameObject warningCircle = Resources.Load<GameObject>("Warning Circle");
        Transform playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        for (int i = 0; i < 6; i++)
        {
            Vector2 spawnPivot = playerTransform.position;

            for (float angle = 0f; angle < 360f; angle += 45f)
            {
                float radian = Mathf.Deg2Rad * angle;

                float x = spawnPivot.x + Mathf.Sin(radian) * 5;
                float y = spawnPivot.y + Mathf.Cos(radian) * 5;

                Instantiate(warningCircle, new Vector3(x, y, 0f), Quaternion.identity);
            }

            yield return new WaitForSeconds(0.9f);

            for (float angle = 0f; angle < 360f; angle += 45f)
            {
                float radian = Mathf.Deg2Rad * angle;

                float x = spawnPivot.x + Mathf.Sin(radian) * 5;
                float y = spawnPivot.y + Mathf.Cos(radian) * 5;

                Instantiate(factoryManager.GetMonster(MonsterTypeEnum.Pattern6), new Vector3(x, y, 0f), Quaternion.identity);
            }

            yield return new WaitForSeconds(4.1f);
        }
    }

    IEnumerator MiddleBoss3Spawn()
    {
        yield return new WaitForSeconds(540f);

        float randomAngle = Random.Range(0f, 360f);

        float radian = Mathf.Deg2Rad * randomAngle;

        float x = myCamera.position.x + Mathf.Sin(radian) * 10;
        float y = myCamera.position.y + Mathf.Cos(radian) * 10;

        Instantiate(factoryManager.GetMonster(MonsterTypeEnum.MiddleBoss3), new Vector3(x, y, 0f), Quaternion.identity);
    }

    IEnumerator LastBossSpawn()
    {
        yield return new WaitForSeconds(600f);

        float randomAngle = Random.Range(0f, 360f);

        float radian = Mathf.Deg2Rad * randomAngle;

        float x = myCamera.position.x + Mathf.Sin(radian) * 10;
        float y = myCamera.position.y + Mathf.Cos(radian) * 10;

        Instantiate(factoryManager.GetMonster(MonsterTypeEnum.LastBoss), new Vector3(x, y, 0f), Quaternion.identity);
    }
}
