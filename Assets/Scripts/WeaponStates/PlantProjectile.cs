/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script launches the vine bullet from the firepoint on the Player
 * Attached to Vine prefab
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantProjectile : MonoBehaviour
{
    private int speed = 7;
    private Vector2 direction = Vector2.right;

    void Start()
    {
        // Get player direction from player to sync the vine bullet with
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        direction = player.GetComponent<PlayerMovement>().facingDirection;

        if (direction == Vector2.left)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        // Destroy gameobject after .5 seconds of it traveling
        Invoke("Die", .5f);
    }

    // Update is called once per frame
    void Update()
    {
        // Vine Bullet movement
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Destroy gameobject
    void Die()
    {
        if (gameObject != null)
            Destroy(gameObject);
    }

    // If the projectile hits an enemy, destroy the vine bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
