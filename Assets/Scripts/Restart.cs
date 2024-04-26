/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This changes to the Main screen after they lose so they can restart
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            
            SceneManager.LoadScene("MainMenu");

            gameManager.health = 100;
            gameManager.reload = 3;
            gameManager.medkit = 1;

            CanvasManager.instance.UpdateMedkit(gameManager.medkit.ToString());
            CanvasManager.instance.UpdateHealth(gameManager.health.ToString());
            CanvasManager.instance.UpdateReload(gameManager.reload.ToString());

        }
    }
}
