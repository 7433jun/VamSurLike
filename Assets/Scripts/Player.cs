using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    [SerializeField] public int level;
    [SerializeField] public float maxExp;
    [SerializeField] public float currentExp;
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;

    [SerializeField] Transform waeponPivot;

    private Vector2 direction;
    private bool hitFlag = true;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private UpgradeManager upgradeManager;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        upgradeManager = GameObject.Find("Upgrade Manager").GetComponent<UpgradeManager>();
    }

    void FixedUpdate()
    {
        if(currentHealth > 0)
        {
            rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

            ImagePlay();
        }
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

    public void Hit(float damage)
    {
        if (hitFlag)
        {
            hitFlag = false;

            animator.SetTrigger("Hit");

            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Walking", false);
                animator.SetBool("Dead", true);

                rigidbody2D.velocity = Vector3.zero;

                StartCoroutine(DeathEvent());
            }
            else
            {
                StartCoroutine(HitFlag());
            }
        }
    }

    public void AddExp(float expPoint)
    {
        currentExp += expPoint;

        if(currentExp >= maxExp)
        {
            currentExp -= maxExp;
            level++;
            maxExp += 5f;

            upgradeManager.LevelUp();
        }
    }

    public void AddHealth(float healthPoint)
    {
        currentHealth += healthPoint;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    IEnumerator DeathEvent()
    {
        yield return new WaitForSeconds(0.5f);

        GameManager.instance.GameEnd(false);
    }

    IEnumerator HitFlag()
    {
        yield return new WaitForSeconds(0.5f);

        hitFlag = true;
    }
}
