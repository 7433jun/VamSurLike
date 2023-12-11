using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MiddleBoss1 : Monster
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

        SpawnManager.normalMonster = MonsterTypeEnum.Normal2;

        StartCoroutine(DeathEvent());
    }

    IEnumerator AttackPattern()
    {
        while (true)
        {
            // 일반 움직임
            yield return new WaitForSeconds(2f);
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
        }
    }

    IEnumerator DeathEvent()
    {
        yield return new WaitForSeconds(0.5f);

        Instantiate(Resources.Load<GameObject>("Heart"), transform.position, quaternion.identity);

        Destroy(gameObject);
    }
}
