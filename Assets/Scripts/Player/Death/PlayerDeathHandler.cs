using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathHandler : MonoBehaviour
{
    // Checks when the player crashes into things and kills the player when they do

    [Tooltip("The player's rigidbody")]
    [SerializeField] Rigidbody playerRigidbody;

    [Tooltip("Is this DeathHandler checking if the player dies when they stand on something?")]
    [SerializeField] bool isGroundCheck;

    // If player hits a non-safe object, send them back to the start of the level
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3 && isGroundCheck) { return; } // As hitting most objects in the game should kill the player, marking the safe objects to touch makes more sense

        LevelManager.Instance.levelAttempt += 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
