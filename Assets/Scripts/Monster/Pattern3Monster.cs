using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Pattern3Monster : Monster
{
    protected override void Start()
    {
        base.Start();

        direction = playerPosition.position - transform.position;

        // 경로 방해하지않게 벡터 방향 회전
        direction = Quaternion.Euler(0, 0, 5f) * direction;
    }

    protected override void Move()
    {


        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        ImagePlay();
    }

    protected override void Death()
    {
        StartCoroutine(DeathEvent());
    }

    IEnumerator DeathEvent()
    {
        yield return new WaitForSeconds(0.5f);

        Instantiate(Resources.Load<GameObject>("Exp Orb"), transform.position, quaternion.identity);

        Destroy(gameObject);
    }
}
