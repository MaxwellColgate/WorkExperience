using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnim : MonoBehaviour
{
    // Rotates the cube when jumping or falling

    [Tooltip("The player's movement script")]
    [SerializeField] Movement playerMovement;

    [Tooltip("How fast the player rotates when jumping or falling")]
    public float rotateSpeed = 0.5f;

    // Rotates cube when jumping or falling off 
    public IEnumerator RotatePlayer()
    {
        float initialRotationQuat = transform.rotation.x; // The player's rotation before they start rotating
        float finalRotation = initialRotationQuat + 90; // The player's rotation after they're done rotating

        float rotateProgress = 0; // How far through rotating the player currently is

        Debug.Log($"Begin spin! next rotation {finalRotation}");

        // Rotate the player 90 degrees
        while (transform.rotation.x < finalRotation)
        {
            // If the player hits the ground before they're done spinning, snap them to the end of their spin
            if(playerMovement.isGrounded == true) 
            { 
                transform.rotation = Quaternion.Euler(finalRotation, transform.rotation.y, transform.rotation.z); 
                yield break; 
            }
            transform.Rotate(1, 0, 0, Space.Self);
            //transform.eulerAngles = new Vector3(Mathf.Lerp(initialRotationQuat.x, finalRotation, rotateProgress), initialRotationQuat.y, initialRotationQuat.z);
            rotateProgress += 0.02f;
            yield return new WaitForSeconds(rotateSpeed);
        }

        // If the player is still in the air (probably because they're falling), keep spinning!
        if(playerMovement.isGrounded == false)
        {
            StartCoroutine(RotatePlayer());
        }
    }
}
