using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform playerTransform;
    Player player;
    bool playerCheck;
    float expPoint = 5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerTransform = GameObject.Find("Player").transform;

        player = playerTransform.GetComponent<Player>();

        //SetColor();
    }

    void Update()
    {
        if (playerCheck)
        {
            transform.position = Vector2.Lerp(transform.position, playerTransform.position + new Vector3(0, 0.5f, 0), 0.01f);
        }
    }

    public void SetColor()
    {
        switch (expPoint)
        {
            case 1:spriteRenderer.color = Color.red; break;
            case 2:spriteRenderer.color = new Color(1, 0.5f, 0); break;
            case 3:spriteRenderer.color = Color.yellow; break;
            case 4:spriteRenderer.color = Color.green; break;
            case 5: spriteRenderer.color = Color.blue; break;
            case 6: spriteRenderer.color = new Color(0.2f, 0, 1); break;
            case 7: spriteRenderer.color = new Color(0.5f, 0, 1); break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerCheck = true;

        if (collision.CompareTag("Player"))
        {
            player.AddExp(expPoint);

            Destroy(gameObject);
        }
    }
}
