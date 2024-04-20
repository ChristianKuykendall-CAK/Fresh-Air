/* Christian Kuykendall
 * Date:
 * Purpose: This script is a child of the Weapon class. It is used
 * to make the player shoot a vine once activated
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : Weapon
{
    public GameObject fire;
    public Transform firePoint;
    private float fireDelay = 0.25f;
    private float nextTimeToFire = 0;
    public Vector2 facingDirection = Vector2.right;

    // Start is called before the first frame update
    private void Start()
    {
        base.Start(); // needed so we still get the animator for the weapon
        type = WeaponType.Vine;
        ammo = 5;
        damage = 20;
    }

    public override void Use()
    {
        animCompWeapon.SetTrigger("isVining");
        Instantiate(fire, firePoint.position, facingDirection == Vector2.left ? Quaternion.Euler(0, 180, 0) : firePoint.rotation); // creates projectile
        nextTimeToFire = Time.time + fireDelay; // firing rate
                                                //    CheckHit();
    }
}
