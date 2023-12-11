using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LastBoss : Monster
{
    private bool isPattern;
    private bool isAttack1;
    private float initSpeed;

    [SerializeField] GameObject warningIcon;

    protected override void Start()
    {
        base.Start();

        warningIcon.SetActive(false);
        initSpeed = speed;
        StartCoroutine(AttackPattern());

    }

    protected override void Move()
    {
        if (isPattern)
        {
            if (isAttack1)
            {
                rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;
            }
        }
        else
        {
            direction = playerPosition.position - transform.position;

            rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;
        }

        ImagePlay();
    }

    protected override void Death()
    {
        warningIcon.SetActive(false);

        StartCoroutine(DeathEvent());
    }

    IEnumerator AttackPattern()
    {
        FactoryManager factoryManager = GameObject.Find("Factory Manager").GetComponent<FactoryManager>();
        GameObject bullet = Resources.Load<GameObject>("Enemy Bullet");
        GameObject warningCircle = Resources.Load<GameObject>("Warning Circle");

        while (true)
        {
            yield return new WaitForSeconds(2f);

            switch (UnityEngine.Random.Range(1, 4))
            {
                case 1:
                    // 경고
                    warningIcon.SetActive(true);

                    isPattern = true;

                    rigidbody2D.velocity = Vector2.zero;

                    yield return new WaitForSeconds(1f);
                    // 돌진 시작
                    warningIcon.SetActive(false);

                    direction = playerPosition.position - transform.position;
                    speed = 300;

                    isAttack1 = true;

                    yield return new WaitForSeconds(2f);
                    // 돌진 종료
                    isPattern = false;
                    isAttack1 = false;
                    speed = initSpeed;

                    break;
                case 2:
                    // 탄막
                    isPattern = true;

                    rigidbody2D.velocity = Vector2.zero;

                    for(int i = 0; i < 20; i++)
                    {
                        yield return new WaitForSeconds(0.2f);

                        Instantiate(bullet, transform.position + Vector3.up, quaternion.identity).GetComponent<EnemyBullet>().Init(attack, playerPosition.position - transform.position + Vector3.down * 0.5f);
                    }

                    yield return new WaitForSeconds(1f);

                    isPattern = false;

                    break;
                case 3:
                    // 소환
                    isPattern = true;

                    rigidbody2D.velocity = Vector2.zero;

                    Vector2 spawnPivot = transform.position;

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

                        Instantiate(factoryManager.GetMonster(MonsterTypeEnum.Normal4), new Vector3(x, y, 0f), Quaternion.identity);
                    }

                    isPattern = false;

                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator DeathEvent()
    {
        yield return new WaitForSeconds(0.5f);

        GameManager.instance.GameEnd(true);
    }
}
