using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }
}
