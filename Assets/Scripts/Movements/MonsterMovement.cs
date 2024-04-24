using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private bool rayDirection = true;

    private int direction = 3;
    private PlayerMovement playerScript;
    private bool isPlayerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        InvokeRepeating("DeathCheck", 1f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPlayerDead)
        {
            LayerMask mask = LayerMask.GetMask("Player");

            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0f, -.8f, 0f), Vector2.down, .2f, ~mask);
            Debug.DrawRay(transform.position + new Vector3(0f, -.8f, 0f), Vector2.down, Color.red, .2f);

            //Debug.Log(hit.collider);

            if (hit.collider == null)
                direction = direction * -1;

            if (rayDirection)
            {
                RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(-.5f, 0f, 0f), Vector2.left, .1f, ~mask);
                Debug.DrawRay(transform.position + new Vector3(-.5f, 0f, 0f), Vector2.left, Color.red, .1f);

                if (hit2.collider != null)
                {
                    flipRay();
                    direction = direction * -1;
                }
            }
            else
            { 
                RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(.5f, 0f, 0f), Vector2.right, .1f, ~mask);
                Debug.DrawRay(transform.position + new Vector3(.5f, 0f, 0f), Vector2.right, Color.red, .1f);

                if (hit2.collider != null)
                {
                    flipRay();
                    direction = direction * -1;
                }
            }

            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - 1 * direction, transform.position.y), Time.deltaTime);
        }
    }

    void flipRay()
    {
        if(rayDirection)
            rayDirection = false;
        else
            rayDirection = true;
    }

    public void DeathCheck()
    {
        isPlayerDead = playerScript.isPlayerDead();
    }
}
