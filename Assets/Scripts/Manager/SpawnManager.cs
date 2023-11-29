using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] Transform myCamera;

    [SerializeField] GameObject Stump;

    void Start()
    {
        StartCoroutine(NormalSpawn());
    }

    void Update()
    {
        
    }

    IEnumerator NormalSpawn()
    {
        while (true)
        {
            if (myCamera != null)
            {
                float randomAngle = Random.Range(0f, 360f);

                // ������ �������� ��ȯ
                float radian = Mathf.Deg2Rad * randomAngle;

                // ���ο� ��ġ ���
                float x = myCamera.position.x + Mathf.Sin(radian) * radius;
                float y = myCamera.position.y + Mathf.Cos(radian) * radius;

                // ���ο� ��ġ ����
                //transform.position = new Vector3(x, y, 0f);

                Instantiate(Stump, new Vector3(x, y, 0f), Quaternion.identity);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
