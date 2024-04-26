/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script toggles the 2D collider on and off of the creature
 * that sprouts from the ground
 * Attached to the DangerHole prefab
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerHoleAttack : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private void Start()
    {
        // Get the BoxCollider2D component attached to this GameObject
        boxCollider = GetComponent<BoxCollider2D>();

        // Start the coroutine to toggle the collider
        StartCoroutine(ToggleCollider());
    }

    // Turns the collider on and off for the enemy
    private IEnumerator ToggleCollider()
    {
        while (true)
        {
            // Deactivate the collider
            boxCollider.enabled = true;

            // Wait .7 seconds
            yield return new WaitForSeconds(.7f);

            // Activate the collider
            boxCollider.enabled = false;

            // Wait .7 seconds
            yield return new WaitForSeconds(.7f);
        }
    }
}
