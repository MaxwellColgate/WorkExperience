using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    // Checks for when the player should die and handles said death

    [Tooltip("The player's rigidbody")]
    [SerializeField] Rigidbody playerRigidbody;

    // If player hits a non-safe object, send them back to the start of the level
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 3) { return; } // As hitting most objects in the game should kill the player, marking the safe objects to touch makes more sense

        gameObject.transform.position = LevelData.Instance.startPos.position;
        playerRigidbody.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
