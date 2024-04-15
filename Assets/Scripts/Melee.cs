using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    private void Start()
    {
        base.Start(); // needed so we still get the animator for the weapon
        type = WeaponType.Melee;
        ammo = -1; // means endless
        damage = 10;

        //if (anim != null && !string.IsNullOrEmpty(customIdleAnimation))
        //{
        //    anim.Play(customIdleAnimation); // Play the custom idle animation specified in the inspector
        //}

    }

    //public override void Use()
    //{
    //    anim.SetBool("isShooting", true);
    //    CheckHit();
    //}
}
