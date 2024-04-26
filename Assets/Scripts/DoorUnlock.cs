/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This scripts unlocks the final door
 * when all keys are found
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    private int key = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the KeyCollected event in the DestroyBox script
        DestroyBox.KeyCollected += UpdateKeyCount;
    }

    private void UpdateKeyCount(int keyCount)
    {
        key++;
        if (key >= 3)
            Destroy(gameObject);
    }
}
