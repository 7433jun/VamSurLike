using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class WeaponStats
{
    public float attack;
    public float speed;
    public int penetration;
    public int amount;
    public float cooldown;
}

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform playerPivot;
    [SerializeField] Transform waeponPivot;
    [SerializeField] List<GameObject> waeponPrefabList;

    public WeaponStats[] weaponStatsArray;

    public IEnumerator Weapon0()
    {
        while (true)
        {
            for (int i = 0; i< weaponStatsArray[0].amount; i++)
            {
                Wind newWind = Instantiate(waeponPrefabList[0], waeponPivot.position, Quaternion.identity).GetComponent<Wind>();

                newWind.direction = (waeponPivot.position - playerPivot.position).normalized;

                newWind.SetStats(weaponStatsArray[0]);

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(weaponStatsArray[0].cooldown - weaponStatsArray[0].amount * 0.1f);
        }
    }

    public IEnumerator Weapon1()
    {
        while (true)
        {
            for (int i = 0; i < weaponStatsArray[1].amount; i++)
            {
                Arrow newArrow = Instantiate(waeponPrefabList[1], playerPivot.position, Quaternion.identity).GetComponent<Arrow>();

                newArrow.SetStats(weaponStatsArray[1]);

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(weaponStatsArray[1].cooldown - weaponStatsArray[1].amount * 0.1f);
        }
    }

    public IEnumerator Weapon2()
    {
        while (true)
        {
            GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

            if(monsters.Length != 0)
            {
                for (int i = 0; i < weaponStatsArray[2].amount; i++)
                {
                    Thunder newThunder = Instantiate(waeponPrefabList[2], monsters[Random.Range(0, monsters.Length)].transform.position, Quaternion.identity).GetComponent<Thunder>();
                    
                    newThunder.SetStats(weaponStatsArray[2]);
                }
            }

            yield return new WaitForSeconds(weaponStatsArray[2].cooldown);
        }
    }

    public IEnumerator Weapon3()
    {
        while (true)
        {
            for (int i = 0; i < weaponStatsArray[3].amount; i++)
            {
                Spike newSpike = Instantiate(waeponPrefabList[3], playerPivot.position, Quaternion.identity).GetComponent<Spike>();

                newSpike.SetStats(weaponStatsArray[3]);

                newSpike.SetSpikeStats(i, weaponStatsArray[3].amount, playerPivot);
            }

            yield return new WaitForSeconds(weaponStatsArray[3].cooldown);
        }
    }

    public IEnumerator Weapon4()
    {
        while (true)
        {
            for (int i = 0; i < weaponStatsArray[4].amount; i++)
            {
                Fire newFire = Instantiate(waeponPrefabList[4], playerPivot.position, Quaternion.identity).GetComponent<Fire>();

                newFire.SetStats(weaponStatsArray[4]);

                yield return new WaitForSeconds(0.3f);
            }

            yield return new WaitForSeconds(weaponStatsArray[4].cooldown - weaponStatsArray[4].amount * 0.3f);
        }
    }

    public IEnumerator Weapon5()
    {
        while (true)
        {
            for (int i = 0; i < weaponStatsArray[5].amount; i++)
            {
                Knife newKnife = Instantiate(waeponPrefabList[5], playerPivot.position, Quaternion.identity).GetComponent<Knife>();

                newKnife.SetStats(weaponStatsArray[5]);

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(weaponStatsArray[5].cooldown - weaponStatsArray[5].amount * 0.1f);
        }
    }

    public IEnumerator Weapon6()
    {
        while (true)
        {
            for (int i = 0; i < weaponStatsArray[6].amount; i++)
            {
                Kunai newKunai = Instantiate(waeponPrefabList[6], playerPivot.position, Quaternion.identity).GetComponent<Kunai>();

                newKunai.SetStats(weaponStatsArray[6]);

                newKunai.SetKunaiStats(i, weaponStatsArray[6].amount);
            }

            yield return new WaitForSeconds(weaponStatsArray[6].cooldown);
        }
    }

    public IEnumerator Weapon7()
    {
        while (true)
        {
            for (int i = 0; i < weaponStatsArray[7].amount; i++)
            {
                Star newStar = Instantiate(waeponPrefabList[7], playerPivot.position, Quaternion.identity).GetComponent<Star>();

                newStar.SetStats(weaponStatsArray[7]);

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(weaponStatsArray[7].cooldown - weaponStatsArray[7].amount * 0.1f);
        }
    }
}
