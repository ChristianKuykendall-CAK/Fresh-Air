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

    //if (anim != null && !string.IsNullOrEmpty(customIdleAnimation))
    //{
    //    anim.Play(customIdleAnimation); // Play the custom idle animation specified in the inspector
    //}



    public override void Use()
    {
        animCompWeapon.SetTrigger("isVining");
        Instantiate(fire, firePoint.position, facingDirection == Vector2.left ? Quaternion.Euler(0, 180, 0) : firePoint.rotation);
        nextTimeToFire = Time.time + fireDelay;
        //    CheckHit();
    }
}
