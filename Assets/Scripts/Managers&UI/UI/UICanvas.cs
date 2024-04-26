/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script is attached to the canvas. It is supposed to change
 * the different values depending on the information it gets about the player
 * states or the weapon.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    public static UICanvas instance;

    public Sprite[] sprites;
    private int currentSpriteIndex = 0;
    public Image image;

    void Start()
    {
        // Set the initial sprite
        if (sprites.Length > 0)
        {
            image.sprite = sprites[currentSpriteIndex];
        }
    }

    void Update()
    {
        // switch weapon images on canvas
        if (Input.GetButtonDown("Fire2"))
        {
            currentSpriteIndex++;

            if (currentSpriteIndex >= sprites.Length)
            {
                currentSpriteIndex = 0;
            }
            image.sprite = sprites[currentSpriteIndex];
        }
    }
}