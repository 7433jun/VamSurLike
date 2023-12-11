using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Weapon
{
    new Rigidbody2D rigidbody2D;

    public Vector2 direction;

    Transform shape;

    float time;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        shape = GetComponentInChildren<SpriteRenderer>().transform;

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

        StartCoroutine(DestroySelf());
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = direction * speed * Time.deltaTime;

        time += Time.fixedDeltaTime;

        shape.localRotation = Quaternion.Euler(Vector3.forward * time * 200);
    }

    void Update()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0)
        {
            if (direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
        if (viewportPosition.x > 1)
        {
            if (direction.x > 0)
            {
                direction.x = -direction.x;
            }
        }
        if (viewportPosition.y < 0)
        {
            if (direction.y < 0)
            {
                direction.y = -direction.y;
            }
        }
        if (viewportPosition.y > 1)
        {
            if (direction.y > 0)
            {
                direction.y = -direction.y;
            }
        }

    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(3f);

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
