using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : Weapon
{
    private int index;
    private int amount;

    new Rigidbody2D rigidbody2D;

    public Vector2 direction;

    bool triggerBlocker;

    // Start is called before the first frame update
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

        if (amount % 2 == 0)
        {
            //direction = direction * Quaternion.Euler(0, 0, (index - (amount + 1) % 2) * 10f);

            direction = Quaternion.Euler(0, 0, (index - (amount) / 2) * 10f + 5f) * direction;
        }
        else
        {
            direction = Quaternion.Euler(0, 0, (index - (amount) / 2) * 10f) * direction;
        }

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        triggerBlocker = true;
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = direction * speed * Time.deltaTime;
    }

    public void SetKunaiStats(int _index, int _amount)
    {
        index = _index;
        amount = _amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerBlocker)
        {
            triggerBlocker = false;

            Monster monster = collision.GetComponent<Monster>();

            if (monster != null)
            {
                if(monster.GetHealth() <= 0)
                {
                    triggerBlocker = true;
                    return;
                }

                monster.Hit(attack);

                penetration--;

                if (penetration <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    triggerBlocker = true;
                }
            }
        }
    }
}
