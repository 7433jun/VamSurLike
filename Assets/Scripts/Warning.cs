using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    float fillAmount;

    [SerializeField] Transform fillCircle;

    void Start()
    {
        fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fillAmount += Time.deltaTime;

        fillCircle.localScale = new Vector3(fillAmount, fillAmount, fillAmount);

        if (fillAmount > 0.9)
        {
            Destroy(gameObject);
        }
    }
}
