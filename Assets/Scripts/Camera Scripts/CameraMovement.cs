using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public Vector3 cameraDistance = new Vector3(0, 1, -5); 

    void Update()
    {
        // Set the camera position relative to the player
        transform.position = player.transform.position + cameraDistance;
    }
}
