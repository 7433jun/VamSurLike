using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float attack;
    private float speed = 300;
    public Vector2 direction;
    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;
    }

    public void Init(float initAttack, Vector2 initDirection)
    {
        attack = initAttack;
        direction = initDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            player.Hit(attack);
        }

        Destroy(gameObject);
    }
}
