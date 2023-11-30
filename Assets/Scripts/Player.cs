using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    [SerializeField] public int level = 1;
    [SerializeField] public float maxExp = 100f;
    [SerializeField] public float currentExp;
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;

    [SerializeField] Vector2 direction;

    [SerializeField] Transform waeponPivot;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        ImagePlay();
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        WeaponPivotPosition();
    }

    public void ImagePlay()
    {
        if (direction != Vector2.zero)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walking", true);

            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
        }
    }

    public void WeaponPivotPosition()
    {
        if (direction != Vector2.zero)
        {
            waeponPivot.localPosition = direction.normalized + new Vector2(0, 0.5f);
            
            // 이거 찾기 뒤지게 힘들었다
            waeponPivot.localRotation = Quaternion.FromToRotation(new Vector2(0, 0.5f), direction.normalized);
        }
    }

    public void AddExp(float expPoint)
    {
        currentExp += expPoint;

        if(currentExp >= maxExp)
        {
            currentExp -= maxExp;
            level++;
        }
    }

    IEnumerator sword()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);


        }
    }
}
