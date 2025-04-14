using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Manages the player's camera

    [Tooltip("The player's camera")]
    [SerializeField] Camera playerCam;

    // Every possible camera position
    public enum cameraPositions
    {
        defaultLeft,
        defaultRight
    };

    [Tooltip("The camera's current position")]
    public cameraPositions currentCameraPos;

    [Tooltip("The transforms for each possible camera position")]
    [SerializeField] List<Transform> cameraPosTransforms;

    void Awake() { }

    // Move the camera to the given position and rotation
    public void SwitchCameraPos(cameraPositions newPos)
    {
        playerCam.gameObject.transform.position = cameraPosTransforms[(int)newPos].position;
        playerCam.gameObject.transform.rotation = cameraPosTransforms[(int)newPos].rotation;
        currentCameraPos = newPos;
    }

}
