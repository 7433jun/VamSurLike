using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    new Rigidbody2D rigidbody2D;

    public Vector2 direction;

    bool triggerBlocker;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        float randomAngle = Random.Range(0f, 360f);

        float radian = Mathf.Deg2Rad * randomAngle;

        float x = Mathf.Sin(radian);
        float y = Mathf.Cos(radian);

        direction = new Vector2(x, y);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        triggerBlocker = true;
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerBlocker)
        {
            triggerBlocker = false;

            Monster monster = collision.GetComponent<Monster>();

            if (monster != null)
            {
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
