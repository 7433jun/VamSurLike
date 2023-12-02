using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : Weapon
{
    new Rigidbody2D rigidbody2D;

    Vector2 direction;

    public Transform playerPivot;
    public Transform waeponPivot;

    // 무기 생성시 관통력보다 더 많은 적을 타격하는 현상 방지용 플래그
    bool triggerBlocker;

    void Start()
    {
        triggerBlocker = true;

        rigidbody2D = GetComponent<Rigidbody2D>();

        direction = (waeponPivot.position - playerPivot.position).normalized;
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
