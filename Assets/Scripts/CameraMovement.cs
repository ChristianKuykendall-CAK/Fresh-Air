/* Christian Kuykendall
 * Date:
 * Purpose: This script is attached to the player gameobject. It is supposed to
 * make the camera follow the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject cameraMovement; // The gameobject is what the camera follows
    private Transform cameraTransform; // Transform of the camera
    private Vector3 offset = new Vector3(0f, 0f, -6f); // How far the camera is from the player

    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = cameraMovement.transform.position + offset; // This follows the players transform position plus whatever the distance
                                                                               // the camera is set away from the player on the z-axis
    }
}
