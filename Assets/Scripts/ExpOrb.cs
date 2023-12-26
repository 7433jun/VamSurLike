using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform playerTransform;
    Player player;
    bool playerCheck;
    [SerializeField] float expPoint;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;

        player = playerTransform.GetComponent<Player>();

        StartCoroutine(RemoveTimer());
    }

    void Update()
    {
        if (playerCheck)
        {
            transform.position = Vector2.Lerp(transform.position, playerTransform.position + new Vector3(0, 0.5f, 0), 0.15f);
        }
    }

    IEnumerator RemoveTimer()
    {
        yield return new WaitForSeconds(60f);

        Destroy(gameObject);
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
