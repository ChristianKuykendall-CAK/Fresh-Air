/* Christian Kuykendall
 * Date:
 * Purpose:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private GameManager gameManager;

    public float xPostition;
    public float yPostition;

    private void Start()
    {
        // Find the GameManager object at runtime
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //get position and changes it
            Vector2 newPosition = new Vector2(xPostition, yPostition);
            collision.gameObject.transform.position = newPosition;

            //updates player health
            gameManager.health -= 10;
            CanvasManager.instance.UpdateHealth(gameManager.health.ToString());
            
        }
    }
}
