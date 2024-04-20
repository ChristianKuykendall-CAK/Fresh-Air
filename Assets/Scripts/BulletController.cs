using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int speed = 15;
    private Vector2 direction = Vector2.right;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //direction = player.GetComponent<Movement>().facingDirection;
        //if (direction == Vector2.left)
        //transform.rotation = Quaternion.Euler(0, 180, 0);
        Invoke("Die", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void Die()
    {
        if (gameObject != null)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
