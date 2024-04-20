using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerHoleAttack : MonoBehaviour
{
    public float moveDistance = 1f; // Distance to move up and down
    public float moveSpeed = 1f;    // Speed of the movement

    private BoxCollider2D collider;
    private Vector3 startPos;
    private bool movingUp = true;

    void Start()
    {
        // Get the BoxCollider2D component attached to this GameObject
        collider = GetComponent<BoxCollider2D>();
        startPos = collider.offset;

        // Start the coroutine to move the collider
        StartCoroutine(MoveColliderCoroutine());
    }

    IEnumerator MoveColliderCoroutine()
    {
        while (true)
        {
            float targetY = movingUp ? startPos.y + moveDistance : startPos.y;
            Vector2 targetOffset = new Vector2(startPos.x, targetY);

            // Move the collider towards the target offset
            while (Vector2.Distance(collider.offset, targetOffset) > 0.01f)
            {
                collider.offset = Vector2.MoveTowards(collider.offset, targetOffset, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Change direction
            movingUp = !movingUp;

            // Wait for a moment before moving again
            yield return new WaitForSeconds(.5f);
        }
    }
}
