/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: When the player falls in a pit take 10 damage
 * then teleport back to the surface
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
