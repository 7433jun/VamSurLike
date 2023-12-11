using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected float attack;
    protected float speed;
    protected int penetration;

    public void SetStats(WeaponStats weaponStats)
    {
        attack = weaponStats.attack;
        speed = weaponStats.speed;
        penetration = weaponStats.penetration;
    }
}
