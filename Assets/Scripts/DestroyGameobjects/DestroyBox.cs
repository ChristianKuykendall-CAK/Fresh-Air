/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script destroy any object the player touches
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyBox : MonoBehaviour
{
    public static event Action<int> KeyCollected;

    private int key = 0;

    // Destroys whatever object this script is attached to
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If the object is 'Key' then add 1 to key to unlock door
            if (gameObject.CompareTag("Key"))
            {
                key++;
                KeyCollected?.Invoke(key);
            }
                // sound byte
                Destroy(gameObject);
        }
    }
}
