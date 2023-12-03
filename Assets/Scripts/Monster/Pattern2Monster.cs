using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Pattern2Monster : Monster
{
    protected override void Start()
    {
        base.Start();

        direction = playerPosition.position - transform.position;
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
