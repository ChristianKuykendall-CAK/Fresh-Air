/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMonster : MonoBehaviour
{
    private Animator anim;
    private AudioSource deathSound;
    private int Health = 200;
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

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Health = Health - damage;
            Debug.Log(Health);

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

