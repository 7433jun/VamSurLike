using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + (Vector3)Random.insideUnitCircle * 0.1f;

        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
