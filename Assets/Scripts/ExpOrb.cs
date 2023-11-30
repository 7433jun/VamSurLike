using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    Transform playerTransform;
    Player player;
    bool playerCheck;
    float expPoint = 5f;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;

        player = playerTransform.GetComponent<Player>();
    }

    void Update()
    {
        if (playerCheck)
        {
            transform.position = Vector2.Lerp(transform.position, playerTransform.position + new Vector3(0, 0.5f, 0), 0.01f);
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
