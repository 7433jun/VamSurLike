using System.Collections;
using System.Collections.Generic;
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

    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerPosition = GameObject.Find("Player").transform;

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

    protected abstract void Move();

    protected abstract void Death();

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enemy attack");
        }
    }
}
