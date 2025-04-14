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
    public void SwitchCameraPos(cameraPositions newPos, float moveSpeed)
    {
        StopAllCoroutines();
        StartCoroutine(moveCamera(cameraPosTransforms[(int)newPos], moveSpeed));
        currentCameraPos = newPos;
    }

    IEnumerator moveCamera(Transform targetPos, float moveSpeed)
    {
        float moveProgress = 0; // How far through the lerp the camera is currently
        Vector3 cameraPosition = transform.position; // The camera's current position
        Quaternion cameraRotation = transform.rotation; // The camera's current rotation

        while(moveProgress <= 1)
        {
            playerCam.gameObject.transform.position = Vector3.Lerp(cameraPosition, targetPos.position, moveProgress);
            playerCam.gameObject.transform.rotation = Quaternion.Lerp(cameraRotation, targetPos.rotation, moveProgress);
            moveProgress += 0.05f;
            yield return new WaitForSeconds(moveSpeed);
        }
    }

}
