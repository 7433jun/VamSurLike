using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BrownStump : Monster
{
    protected override void Death()
    {
        StartCoroutine(DeathEvent());
    }

    IEnumerator DeathEvent()
    {
        yield return new WaitForSeconds(0.5f);

        Instantiate(expOrb, transform.position, quaternion.identity);

        Destroy(gameObject);
    }
}
