/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This changes to the win scene when the player wins
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Win");
        }
    }
}
