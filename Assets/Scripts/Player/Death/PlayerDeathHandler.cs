using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    // Checks when the player crashes into things and kills the player when they do

    [Tooltip("The player's rigidbody")]
    [SerializeField] Rigidbody playerRigidbody;

    // If player hits a non-safe object, send them back to the start of the level
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3) { return; } // As hitting most objects in the game should kill the player, marking the safe objects to touch makes more sense

        Transform startPos = LevelData.Instance.startPos; // The level's starting position

        transform.parent.transform.position = startPos.position;
        playerRigidbody.velocity = Vector3.zero;
        transform.parent.rotation = startPos.rotation;
    }
}
