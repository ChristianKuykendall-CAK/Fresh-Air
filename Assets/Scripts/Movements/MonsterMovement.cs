using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    private int direction = 3;
    private PlayerMovement playerScript;
    private bool isPlayerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        FlipX();
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

            if (hit.collider == null) {
                direction = direction * -1;
                FlipX();
            }


            RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(-.5f, -.6f, 0f), Vector2.left, .1f, ~mask);
            Debug.DrawRay(transform.position + new Vector3(-.5f, -.6f, 0f), Vector2.left, Color.red, .1f);

            if (hit2.collider != null)
            {
                direction = direction * -1;
                FlipX();
            }

            RaycastHit2D hit3 = Physics2D.Raycast(transform.position + new Vector3(.5f, -.6f, 0f), Vector2.right, .1f, ~mask);
            Debug.DrawRay(transform.position + new Vector3(.5f, -.6f, 0f), Vector2.right, Color.red, .1f);

            if (hit3.collider != null)
            {
                direction = direction * -1;
                FlipX();
            }


            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - 1 * direction, transform.position.y), Time.deltaTime);
        }
    }

    public void DeathCheck()
    {
        isPlayerDead = playerScript.isPlayerDead();
    }

    void FlipX()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;
    }
}
