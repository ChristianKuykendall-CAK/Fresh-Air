/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script gets the health, medkit, and reload data from
 * the gamemanager and displays it on the UI as the green text
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public Text healthText;
    public Text reloadText;
    public Text medkitText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Get the CanvasManager instance
        instance = this;
        GameManager gameManager = GetComponent<GameManager>();

        // Set UI info
        UpdateHealth(gameManager.health.ToString());
        UpdateReload(gameManager.reload.ToString());
        UpdateMedkit(gameManager.medkit.ToString());
    }

    void Update()
    {
        GameManager gameManager = GetComponent<GameManager>();

        UpdateHealth(gameManager.health.ToString());
        UpdateReload(gameManager.reload.ToString());
        UpdateMedkit(gameManager.medkit.ToString());
    }

    // displays player's health
    public void UpdateHealth(string txthealth)
    {
        healthText.text = "Health: " + txthealth;
    }

    // Displays ammo boxes left
    public void UpdateReload(string txtreload)
    {
        reloadText.text = txtreload;
    }
    // Displays medkits left
    public void UpdateMedkit(string txtmedkit)
    {
        medkitText.text = txtmedkit;
    }
}
