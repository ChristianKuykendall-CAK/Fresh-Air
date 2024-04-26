/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script is attached to the danger hole so that the player can damage it
 */
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
        if (playerMovement.activeWeaponIndex == 0) // Punch
        {
            damage = 5;
        }
        else if (playerMovement.activeWeaponIndex == 1) // Gun
        {
            damage = 15;
        }
        else if (playerMovement.activeWeaponIndex == 2) // Vine
        {
            damage = 30;
        }
    }
    // If it gets hit with a projeictle take damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Health = Health - damage;
            Debug.Log(Health);
            // If it runs out of health then die
            if (Health <= 0)
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

