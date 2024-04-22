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

    private IEnumerator ToggleCollider()
    {
        while (true)
        {
            // Deactivate the collider
            boxCollider.enabled = true;

            // Wait for a certain amount of time
            yield return new WaitForSeconds(.7f);

            // Activate the collider
            boxCollider.enabled = false;

            // Wait for another amount of time
            yield return new WaitForSeconds(.7f);
        }
    }
}
