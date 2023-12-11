using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : Weapon
{
    void Start()
    {
        StartCoroutine(ActiveCollider());
        StartCoroutine(DestroySelf());
    }

    IEnumerator ActiveCollider()
    {
        yield return new WaitForSeconds(0.3f);

        GetComponent<CircleCollider2D>().enabled = true;
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(0.6f);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.GetComponent<Monster>();

        if (monster != null)
        {
            monster.Hit(attack);
        }
    }
}
