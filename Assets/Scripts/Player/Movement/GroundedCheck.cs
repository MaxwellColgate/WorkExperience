using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    // Checks if the player is currently on the ground before they can jump

    [Tooltip("The player's movement script")]
    [SerializeField] Movement playerMovement;

    int collidersEntered; // The number of colliders the player is touching

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") { return; }
        collidersEntered += 1;
        playerMovement.isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player") { return; }
        collidersEntered -= 1;
        if(collidersEntered == 0)
        {
            playerMovement.isGrounded = false;
        }
    }
}
