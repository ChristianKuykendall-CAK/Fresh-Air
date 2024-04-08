using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    private void Start()
    {
        base.Start(); // needed so we still get the animator for the weapon
        type = WeaponType.Gun;
        ammo = -1; // means endless
        damage = 10;

        //if (anim != null && !string.IsNullOrEmpty(customIdleAnimation))
        //{
        //    anim.Play(customIdleAnimation); // Play the custom idle animation specified in the inspector
        //}

        //distance = 1;
        //GameObject fire;
        //Transform firePoint;
        //Vector2 facingDirection = Vector2.right;
    }

    //public override void Use()
    //{
    //    anim.SetBool("isShooting", true);
    //    CheckHit();
    //}
}
