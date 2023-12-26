using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NormalMonster : Monster
{
    protected override void Move()
    {
        direction = playerPosition.position - transform.position;

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

        if (UnityEngine.Random.value < 0.02f)
        {
            Instantiate(Resources.Load<GameObject>("Heart"), transform.position, quaternion.identity);
        }
        else
        {
            Instantiate(Resources.Load<GameObject>("Exp Orb"), transform.position, quaternion.identity);
        }

        Destroy(gameObject);
    }
}
