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

    //This displays the options menu makes sure the player is not still able to
    //type in the input field when the options menu is displayed
    void DisplayOptions()
    {
        settingsCanvas.gameObject.SetActive(true);
    }

    //This hides the options menu as well as turn the input field back on
    void HideOptions()
    {
        settingsCanvas.gameObject.SetActive(false);
    }
}