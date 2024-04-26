/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyBox : MonoBehaviour
{
    public static event Action<int> KeyCollected;

    private int key = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
