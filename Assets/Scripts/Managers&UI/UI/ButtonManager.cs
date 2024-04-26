using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

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
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(startGame);
        helpButton.onClick.AddListener(helpMenu);
        quitButton.onClick.AddListener(quitGame);
        backButton.onClick.AddListener(backMain);
    }
    void startGame()
    {
        Debug.Log("StartGame() function called");
        SceneManager.LoadScene("Level_1");
    }
    void helpMenu()
    {
        Debug.Log("helpMenu() function called");
        SceneManager.LoadScene("HelpMenu");
    }
    void quitGame()
    {
        Debug.Log("quitGame() function called");
        Application.Quit();
    }
    void backMain()
    {
        Debug.Log("backMain() function called");
        SceneManager.LoadScene("MainMenu");
    }
}
