/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script moves the monster left and right of the screen.
 * Attached to Monster prefab
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    private int direction = 3;
    private PlayerMovement playerScript;
    private bool isPlayerDead = false;

    void Start()
    {
        FlipX();
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        InvokeRepeating("DeathCheck", 1f, 1f);
    }


    void FixedUpdate()
    {
        if (!isPlayerDead)
        {
            // Avoids the Player so it can touch the player before having to turn around
            LayerMask mask = LayerMask.GetMask("Player");

            // Raycast down
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0f, -.8f, 0f), Vector2.down, .2f, ~mask);
            Debug.DrawRay(transform.position + new Vector3(0f, -.8f, 0f), Vector2.down, Color.red, .2f);

            if (hit.collider == null)
            {
                ChangeDirection();
            }

            // Raycast left
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(-.5f, -.6f, 0f), Vector2.left, .1f, ~mask);
            Debug.DrawRay(transform.position + new Vector3(-.5f, -.6f, 0f), Vector2.left, Color.red, .1f);

            if (hit2.collider != null)
            {
                ChangeDirection();
            }

            // Raycast right
            RaycastHit2D hit3 = Physics2D.Raycast(transform.position + new Vector3(.5f, -.6f, 0f), Vector2.right, .1f, ~mask);
            Debug.DrawRay(transform.position + new Vector3(.5f, -.6f, 0f), Vector2.right, Color.red, .1f);

            if (hit3.collider != null)
            {
                ChangeDirection();
            }

            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - 1 * direction, transform.position.y), Time.deltaTime);
        }
    }

    //Changes direction the monster moves
    public void ChangeDirection()
    {
        direction = direction * -1;
        FlipX();
    }

    // Checks to see if the player is dead
    public void DeathCheck()
    {
        isPlayerDead = playerScript.isPlayerDead();
    }

    // Flips the gameobject to walk in the correct direction
    void FlipX()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;
    }
}
