/* Christian Kuykendall
 * Date:
 * Purpose: This script is a child of the Weapon class. It is used
 * to make the player shoot a bullet once activated
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
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
        type = WeaponType.Gun;
        ammo = 10; // means endless
        damage = 10;
    }

    public override void Use()
    {
        if (ammo > 0) {
            Instantiate(fire, firePoint.position, facingDirection == Vector2.left ? Quaternion.Euler(0, 180, 0) : firePoint.rotation); // creates projectile
            nextTimeToFire = Time.time + fireDelay; // firing rate
            ammo--;
        }
    }
}
