/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script is a child of the Weapon class. It is used
 * to make the player punch once activated
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    public GameObject fire;
    public Transform firePoint;
    private float fireDelay = 0.25f;
    private float nextTimeToFire = 0;
    public Vector2 facingDirection = Vector2.right;


    private void Start()
    {
        base.Start(); // needed so we still get the animator for the weapon
        type = WeaponType.Melee;
        ammo = -1; // means endless
        damage = 10;
    }

    // Once used, create a projectile that damages enemies.
    public override void Use()
    {
        Instantiate(fire, firePoint.position, facingDirection == Vector2.left ? Quaternion.Euler(0, 180, 0) : firePoint.rotation); // creates projectile
        nextTimeToFire = Time.time + fireDelay; // firing rate
    }
}
