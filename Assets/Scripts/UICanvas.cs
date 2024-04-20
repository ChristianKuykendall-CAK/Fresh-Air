/* Christian Kuykendall
 * Date:
 * Purpose: This script is attached to the canves. It is supposed to change
 * the different values depending on the information it gets about the player
 * states or the weapon.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    public static UICanvas instance; // Instance

    public Sprite[] sprites; // Array to hold different sprites
    private int currentSpriteIndex = 0; // Index of the current sprite
    private Image image; // Reference to the Image component

    // Start is called before the first frame update
    void Start()
    {
        // Get the Image component attached to the GameObject
        image = GetComponent<Image>();

        // Set the initial sprite
        if (sprites.Length > 0)
        {
            image.sprite = sprites[currentSpriteIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for Tab key press
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentSpriteIndex++; // Increments the current sprite index

            // Go back to start of array
            if (currentSpriteIndex >= sprites.Length)
            {
                currentSpriteIndex = 0;
            }
            image.sprite = sprites[currentSpriteIndex]; // Changes sprite
        }
    }
}