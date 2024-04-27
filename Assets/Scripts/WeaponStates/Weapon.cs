/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script holds all of the weapons the player uses and
 * iterates through each weapon.
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType { Melee, Gun, Vine }; // different weapons

    protected WeaponType type;

    protected int damage;
    protected int distance;
    [SerializeField]
    protected int ammo;

    public Animator animCompWeapon;
    public Transform parentTransform;

    public virtual void Use()
    {
        // child classes will override
    }
    public void Start()
    {
        animCompWeapon = GameObject.FindGameObjectWithTag("weapons").GetComponent<Animator>();
    }

    // This reloads each weapon
    public void Reload()
    {
        switch(type)
        {
            case WeaponType.Gun:
                ammo = 10;
                break;
            case WeaponType.Vine:
                ammo = 5;
                break;
            case WeaponType.Melee:
                break;
        }
    }
}
