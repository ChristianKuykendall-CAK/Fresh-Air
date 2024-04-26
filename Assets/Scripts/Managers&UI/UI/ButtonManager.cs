/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script gets the buttons for th emain menu so that
 * the scenes can be switched
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    private GameManager gameManager;

    // Buttons
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button helpButton;
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Button backButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Listeners
        startButton.onClick.AddListener(startGame);
        helpButton.onClick.AddListener(helpMenu);
        quitButton.onClick.AddListener(quitGame);
        backButton.onClick.AddListener(backMain);
    }
    // Go to level_1
    void startGame()
    {
        Debug.Log("StartGame() function called");
        SceneManager.LoadScene("Level_1");
        Destroy(gameObject);
    }
    // Go to help menu
    void helpMenu()
    {
        Debug.Log("helpMenu() function called");
        SceneManager.LoadScene("HelpMenu");
        // toggle button visibility on and off
        startButton.gameObject.SetActive(false);
        helpButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }
    // quit game
    void quitGame()
    {
        Debug.Log("quitGame() function called");
        Application.Quit();
    }
    // go back to main menu
    void backMain()
    {
        Debug.Log("backMain() function called");
        SceneManager.LoadScene("MainMenu");
        startButton.gameObject.SetActive(true);
        helpButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
    }

}
