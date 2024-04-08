using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //This should be the player
    public GameObject cameraMovement;
    private Transform cameraTransform;
    // distance camera is from player
    private Vector3 offset = new Vector3(0f, 0f, -6f);

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //This follows the players transform position plus whatever the distance the camera is set away from the player on the z-axis
        cameraTransform.position = cameraMovement.transform.position + offset;
    }
}
