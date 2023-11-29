using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] protected float speed;
    [SerializeField] protected float attack;
    [SerializeField] Vector2 direction;
    [SerializeField] Transform playerPosition;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerPosition = GameObject.Find("Player").transform;

        animator.SetBool("Walking", true);
    }

    void FixedUpdate()
    {


        Move();
    }

    protected void Move()
    {
        direction = new Vector2(playerPosition.position.x - transform.position.x, playerPosition.position.y - transform.position.y);

        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        ImagePlay();
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

    protected abstract void Death();

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enemy attack");
        }
    }
}
