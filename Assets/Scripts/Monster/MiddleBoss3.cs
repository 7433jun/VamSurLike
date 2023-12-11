using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MiddleBoss3 : Monster
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
        SpawnManager.normalMonster = MonsterTypeEnum.Normal4;

        StartCoroutine(DeathEvent());
    }

    IEnumerator AttackPattern()
    {
        GameObject bullet = Resources.Load<GameObject>("Enemy Bullet");

        while (true)
        {
            yield return new WaitForSeconds(2f);

            Vector2 bulletDirection = (direction + Vector2.down * 0.5f).normalized;

            Vector3 bulletPosition = (bulletDirection + new Vector2(-bulletDirection.y, bulletDirection.x)) * 0.4f;
            Instantiate(bullet, transform.position + Vector3.up + bulletPosition, quaternion.identity).GetComponent<EnemyBullet>().Init(attack, bulletDirection);

            bulletPosition = (bulletDirection + new Vector2(bulletDirection.y, -bulletDirection.x)) * 0.4f;
            Instantiate(bullet, transform.position + Vector3.up + bulletPosition, quaternion.identity).GetComponent<EnemyBullet>().Init(attack, bulletDirection);

            bulletPosition = (-bulletDirection + new Vector2(-bulletDirection.y, bulletDirection.x)) * 0.4f;
            Instantiate(bullet, transform.position + Vector3.up + bulletPosition, quaternion.identity).GetComponent<EnemyBullet>().Init(attack, bulletDirection);

            bulletPosition = (-bulletDirection + new Vector2(bulletDirection.y, -bulletDirection.x)) * 0.4f;
            Instantiate(bullet, transform.position + Vector3.up + bulletPosition, quaternion.identity).GetComponent<EnemyBullet>().Init(attack, bulletDirection);
        }
    }

    IEnumerator DeathEvent()
    {
        yield return new WaitForSeconds(0.5f);

        Instantiate(Resources.Load<GameObject>("Heart"), transform.position, quaternion.identity);

        Destroy(gameObject);
    }
}
