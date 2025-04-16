using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnim : MonoBehaviour
{
    // Rotates the player when jumping or falling

    [Tooltip("The player's movement script")]
    [SerializeField] Movement playerMovement;

    [Tooltip("How far the player rotates in one jump")]
    public float finalRotation = 180;

    bool isRotating; // Ensures only one coroutine is running at any point

    // Rotate player until they land
    public IEnumerator RotatePlayer()
    {
        if (isRotating) { yield break; }
        isRotating = true;

        Quaternion targetRotation = new Quaternion(transform.rotation.x + 90, 0, 0, 1); // The player's rotation after they're done rotating, assumes that the player will always be spinning only forwards

        // Rotate player 90 degrees
        while (transform.rotation.x < targetRotation.x)
        {
            // If the player hits the ground before they're done spinning, snap them to the end of their spin
            if(playerMovement.isGrounded == true) 
            { 
                transform.localRotation = targetRotation;
                isRotating = false;
                yield break; 
            }
            transform.Rotate(finalRotation * Time.deltaTime, 0, 0, Space.Self);
            yield return null;
        }

        isRotating = false;

        // If the player is still in the air (probably because they're falling), keep spinning!
        if(playerMovement.isGrounded == false)
        {
            StartCoroutine(RotatePlayer());
        }
    }
}
