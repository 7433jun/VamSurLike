using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Weapon
{
    private int index;
    private int amount;
    private Transform playerPivot;

    private float time;

    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time > 360)
            time -= 360;

        float radian = Mathf.Deg2Rad * (time * speed + (index * 360f / amount));

        float x = Mathf.Sin(radian) * 2;
        float y = Mathf.Cos(radian) * 2;

        transform.position = playerPivot.position + new Vector3(x, y);
    }

    public void SetSpikeStats(int _index, int _amount, Transform _playerPivot)
    {
        index = _index;
        amount = _amount;
        playerPivot = _playerPivot;
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.GetComponent<Monster>();

        if (monster != null)
        {
            monster.Hit(attack);
        }
    }
}
