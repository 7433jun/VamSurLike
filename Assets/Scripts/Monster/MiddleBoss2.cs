using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MiddleBoss2 : Monster
{
    protected override void Start()
    {
        base.Start();

        StartCoroutine(AttackPattern());
    }

    protected override void Move()
    {
        direction = playerPosition.position - transform.position;

        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        ImagePlay();
    }

    protected override void Death()
    {
        SpawnManager.normalMonster = MonsterTypeEnum.Normal3;

        StartCoroutine(DeathEvent());
    }

    IEnumerator AttackPattern()
    {
        GameObject bullet = Resources.Load<GameObject>("Enemy Bullet");

        while (true)
        {
            yield return new WaitForSeconds(2f);

            for (int i = 0; i < 8; i++)
            {
                float radian = Mathf.Deg2Rad * i * 45f;

                Instantiate(bullet, transform.position + Vector3.up, quaternion.identity).GetComponent<EnemyBullet>().Init(attack, new Vector2(Mathf.Sin(radian), Mathf.Cos(radian)));
            }
        }
    }

    IEnumerator DeathEvent()
    {
        yield return new WaitForSeconds(0.5f);

        Instantiate(Resources.Load<GameObject>("Heart"), transform.position, quaternion.identity);

        Destroy(gameObject);
    }
}
