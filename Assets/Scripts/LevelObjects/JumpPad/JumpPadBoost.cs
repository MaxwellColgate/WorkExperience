using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadBoost : MonoBehaviour
{
    // Boosts the player upwards when they hit a jump pad

    [Tooltip("How hard the player is launched upwards")]
    [SerializeField] float boostStrength = 8;

    [Tooltip("The jump pad's boing sound effect")]
    [SerializeField] AudioSource jumpPadSFX;

    // Reset the player's y velocity and then boost them upwards
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player") { return; }

        Rigidbody playerBody = other.gameObject.GetComponentInParent<Rigidbody>();

        playerBody.velocity = new Vector3(playerBody.velocity.x, boostStrength, playerBody.velocity.z);
        //playerBody.AddForce(Vector3.up * boostStrength, ForceMode.Impulse);
        other.gameObject.GetComponentInParent<Movement>().isGrounded = false;

        jumpPadSFX.Play();
    }
}
