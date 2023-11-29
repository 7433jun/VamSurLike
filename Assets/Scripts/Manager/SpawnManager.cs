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

                // 각도를 라디안으로 변환
                float radian = Mathf.Deg2Rad * randomAngle;

                // 새로운 위치 계산
                float x = myCamera.position.x + Mathf.Sin(radian) * radius;
                float y = myCamera.position.y + Mathf.Cos(radian) * radius;

                // 새로운 위치 설정
                //transform.position = new Vector3(x, y, 0f);

                Instantiate(Stump, new Vector3(x, y, 0f), Quaternion.identity);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
