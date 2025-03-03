/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script is attached to all collectable objects.
 * It is used to make them move up and down slightly so they can stand out
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    private SpriteRenderer renderer;
    private float distance = .2f;
    private float amount = .2f;
    private float movement = .2f;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        StartCoroutine("HoverItem");
    }

    IEnumerator HoverItem()
    {
        while (true)
        {
            transform.Translate(new Vector2(0, distance * movement));
            amount--;
            if (amount <= 0)
            {
                movement = movement * -1;
                amount = 5;
            }
            yield return new WaitForSeconds(.2f);
        }
    }
}
