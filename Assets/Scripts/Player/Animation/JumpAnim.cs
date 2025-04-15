using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnim : MonoBehaviour
{
    // Rotates the player when jumping or falling

    [Tooltip("The player's movement script")]
    [SerializeField] Movement playerMovement;

    [Tooltip("How fast the player rotates when jumping or falling")]
    public float rotateSpeed = 0.5f;

    // Rotate player until they land
    public IEnumerator RotatePlayer()
    {
        Quaternion finalRotation = new Quaternion(transform.rotation.x + 90, 0, 0, 1); // The player's rotation after they're done rotating, assumes that the player will always be spinning only forwards

        Debug.Log($"Begin spin! next rotation {finalRotation.x}");

        // Rotate player 90 degrees
        while (transform.rotation.x < finalRotation.x)
        {
            // If the player hits the ground before they're done spinning, snap them to the end of their spin
            if(playerMovement.isGrounded == true) 
            { 
                transform.localRotation = finalRotation; 
                yield break; 
            }
            transform.Rotate(1, 0, 0, Space.Self);
            yield return new WaitForSeconds(rotateSpeed);
        }

        // If the player is still in the air (probably because they're falling), keep spinning!
        if(playerMovement.isGrounded == false)
        {
            StartCoroutine(RotatePlayer());
        }
    }
}
