/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: Gamemager Script
 * Holds, health, medkits, and reloads.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int health = 100;
    public int reload = 3;
    public int medkit = 1;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        reload = 3;
        medkit = 1;
    }

    // If medkits is used the set player health to 100
    public void UseMedkit()
    {
        health = 100;
    }
}
