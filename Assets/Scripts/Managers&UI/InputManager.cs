/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script allows the player to display the options menu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public Canvas settingsCanvas;
    private bool displayed = false;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Once player presses 'P' Turn on unless already on
        // then turn off
        if (Input.GetKeyDown(KeyCode.P) && !displayed)
        {
            DisplayOptions();
            displayed = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && displayed)
        {
            HideOptions();
            displayed = false;
        }
    }

    // Displays the options menu
    void DisplayOptions()
    {
        settingsCanvas.gameObject.SetActive(true);
    }

    // Hides the options menu
    void HideOptions()
    {
        settingsCanvas.gameObject.SetActive(false);
    }
}