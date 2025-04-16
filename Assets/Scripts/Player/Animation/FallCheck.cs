using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour
{
    // Checks of the player should be rotating, only checks with colliders on back half of the player so that they rotate properly when falling off objects

    [Tooltip("The player's rotate animation script")]
    [SerializeField] RotateAnim rotateAnim;

    int collidersEntered; // The number of colliders the player is touching

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") { collidersEntered += 1; }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player") { return; }
        collidersEntered -= 1;
        if (collidersEntered == 0)
        {
            StartCoroutine(rotateAnim.RotatePlayer());
        }
    }
}
