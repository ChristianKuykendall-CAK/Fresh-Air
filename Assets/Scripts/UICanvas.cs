using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    public static UICanvas instance;

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
            // Increment the current sprite index
            currentSpriteIndex++;

            // Wrap around if we reach the end of the array
            if (currentSpriteIndex >= sprites.Length)
            {
                currentSpriteIndex = 0;
            }

            // Change the sprite
            image.sprite = sprites[currentSpriteIndex];
        }
    }
}