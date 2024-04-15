using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType { Melee, Gun, Vine }; // attacks

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

    protected void CheckHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(parentTransform.position, parentTransform.TransformDirection(Vector3.forward), out hit, distance))
        {
            Debug.Log("Hit something!");
            GameObject enemy = hit.collider.gameObject;

            if (enemy.CompareTag("enemy"))
            {
                MonsterMovement enemy_controller = enemy.GetComponent<MonsterMovement>();
                //enemy_controller.health -= damage;
            }
        }
        Debug.DrawRay(transform.position, Vector3.forward, Color.red, 2f); // will not show depth
    }
    void Update()
    {
        
    }
    public void Reload()
    {
        ammo = 10;
    }
}
