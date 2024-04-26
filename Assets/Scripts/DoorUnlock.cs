/* Christian Kuykendall
 * Date:
 * Purpose:
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
