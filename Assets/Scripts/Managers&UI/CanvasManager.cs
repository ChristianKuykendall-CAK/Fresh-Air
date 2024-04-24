using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public Text healthText;

    public Text reloadText;

    void Start()
    {
        // Get the CanvasManager instance
        instance = this;

        GameManager gameManager = GetComponent<GameManager>();

        UpdateHealth(gameManager.health.ToString());

        UpdateReload(gameManager.reload.ToString());
    }

    void Update()
    {
        GameManager gameManager = GetComponent<GameManager>();

        UpdateHealth(gameManager.health.ToString());

        UpdateReload(gameManager.reload.ToString());
       
    }

    public void UpdateHealth(string txthealth)
    {
        healthText.text = "Health: " + txthealth;
    }

    public void UpdateReload(string txtreload)
    {
        //Debug.Log(txtreload);
        reloadText.text = "Boxes: " + txtreload;
    }
}
