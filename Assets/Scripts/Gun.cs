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

    private void Start() 
    {
        base.Start(); // needed so we still get the animator for the weapon
        type = WeaponType.Gun;
        ammo = -1; // means endless
        damage = 10;
    }
    
        


        //if (anim != null && !string.IsNullOrEmpty(customIdleAnimation))
        //{
        //    anim.Play(customIdleAnimation); // Play the custom idle animation specified in the inspector
        //}

        //distance = 1;
        //GameObject fire;
        //Transform firePoint;
        //Vector2 facingDirection = Vector2.right;
    

    public override void Use()
    {
        animCompWeapon.SetTrigger("isShooting");
        Instantiate(fire, firePoint.position, facingDirection == Vector2.left ? Quaternion.Euler(0, 180, 0) : firePoint.rotation);
        nextTimeToFire = Time.time + fireDelay;
    //    CheckHit();
    }
}
