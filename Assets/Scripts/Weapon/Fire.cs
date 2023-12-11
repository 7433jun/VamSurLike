using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Weapon
{
    new Rigidbody2D rigidbody2D;

    public Vector2 direction;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        float closestdist = Mathf.Infinity;

        GameObject closestMonster = null;

        foreach (GameObject monster in GameObject.FindGameObjectsWithTag("Monster"))
        {
            if (monster.GetComponent<Monster>().GetHealth() <= 0) continue;

            float dist = (transform.position - monster.transform.position).sqrMagnitude;

            if (dist < closestdist)
            {
                closestdist = dist;

                closestMonster = monster;
            }
        }

        if (closestMonster != null)
        {
            direction = (closestMonster.transform.position - transform.position + Vector3.up * 0.5f).normalized;
        }
        else
        {
            direction = Vector2.up;
        }

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = direction * speed * Time.deltaTime;
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
