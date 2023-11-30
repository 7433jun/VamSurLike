using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float limitX;
    [SerializeField] float limitY;

    void Update()
    {
        Vector3 vector3 = player.position + new Vector3(0, 0.5f, 0);

        float clampedX = Mathf.Clamp(vector3.x, -limitX, limitX);
        float clampedY = Mathf.Clamp(vector3.y, -limitY, limitY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
