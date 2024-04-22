using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadDangerHole : MonoBehaviour
{
    private Animator anim;
    private AudioSource deathSound;
    private int Health = 100;
    private int damage = 0;

    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.activeWeaponIndex == 0) // Vine
        {
            damage = 30;
        }
        else if (playerMovement.activeWeaponIndex == 1) // Gun
        {
            damage = 15;
        }
        else if (playerMovement.activeWeaponIndex == 2) // Punch
        {
            damage = 5;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Fire"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Health = Health - damage;
            //anim.SetBool("isDead", true);
            //GetComponent<Patrol>().enabled = false;
            //deathSound.Play();
            if (Health < 0)
            {
                Invoke("Die", 1f);
            }
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

