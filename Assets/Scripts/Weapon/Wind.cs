using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : Weapon
{
    new Rigidbody2D rigidbody2D;

    Vector2 direction;

    public Transform playerPivot;
    public Transform waeponPivot;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        direction = (waeponPivot.position - playerPivot.position).normalized;
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.GetComponent<Monster>();

        monster.Hit(attack);

        penetration--;
        if (penetration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
