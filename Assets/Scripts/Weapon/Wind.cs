using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : Weapon
{
    new Rigidbody2D rigidbody2D;

    public Vector2 direction;

    // ���� ������ ����º��� �� ���� ���� Ÿ���ϴ� ���� ������ �÷���
    bool triggerBlocker;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

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
