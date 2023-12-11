using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected new Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] protected float speed;
    [SerializeField] protected float attack;
    [SerializeField] protected float health;

    public Vector2 direction;
    protected Transform playerPosition;
    GameObject floatingText;

    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerPosition = GameObject.Find("Player").transform;
        floatingText = Resources.Load<GameObject>("Damage Text");

        animator.SetBool("Walking", true);
    }

    void FixedUpdate()
    {
        if (health > 0)
        {
            Move();
        }
    }

    public void ImagePlay()
    {
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Hit(float damage)
    {
        health -= damage;

        Instantiate(floatingText, transform.position + Vector3.up * 0.5f, quaternion.identity).GetComponent<TextMeshPro>().text = $"{damage}";

        animator.SetTrigger("Hit");

        if(health <= 0)
        {
            rigidbody2D.velocity = Vector2.zero;

            GetComponent<CircleCollider2D>().enabled = false;

            animator.SetBool("Walking", false);
            animator.SetBool("Dead", true);

            Death();
        }
    }

    public float GetHealth()
    {
        return health;
    }

    protected abstract void Move();

    protected abstract void Death();

    protected void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            player.Hit(attack);
        }
    }
}
