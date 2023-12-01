using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform playerPivot;
    [SerializeField] Transform waeponPivot;
    [SerializeField] List<GameObject> waeponList;

    void Start()
    {
        StartCoroutine(WindCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WindCoroutine()
    {
        while (true)
        {
            WindShot();

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void WindShot()
    {
        Wind newWind = Instantiate(waeponList[0], waeponPivot.position, quaternion.identity).GetComponent<Wind>();

        newWind.playerPivot = playerPivot;
        newWind.waeponPivot = waeponPivot;
    }
}
