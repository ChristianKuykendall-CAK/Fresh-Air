/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script launches the fist projectile from the firepoint on the Player.
 * Since this is melee the projectile is invisible
 * Attached to Fist prefab
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAttack : MonoBehaviour
{
    private int speed = 0;
    private Vector2 direction = Vector2.right;

    void Start()
    {
        // Get player direction from player to sync the fist with
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        direction = player.GetComponent<PlayerMovement>().facingDirection;

        if (direction == Vector2.left)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        // Destroy gameobject after .1 seconds of it traveling
        Invoke("Die", .1f);
    }

    // Update is called once per frame
    void Update()
    {
        // Punch movement
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Destroys gameobject
    void Die()
    {
        if (gameObject != null)
            Destroy(gameObject);
    }

    // Destroys gameobject once it collides with an enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
