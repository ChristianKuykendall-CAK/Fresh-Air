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

    void Start()
    {
        // Get the CanvasManager instance
        instance = this;

        GameManager gameManager = GetComponent<GameManager>();

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

    public void UpdateHealth(string txthealth)
    {
        healthText.text = "Health: " + txthealth;
    }

    public void UpdateReload(string txtreload)
    {
        reloadText.text = "Boxes: " + txtreload;
    }
    public void UpdateMedkit(string txtmedkit)
    {
        medkitText.text = "Medkits: " + txtmedkit;
    }
}
