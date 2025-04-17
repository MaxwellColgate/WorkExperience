using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathHandler : MonoBehaviour
{
    // Checks when the player crashes into things and kills the player when they do

    [Tooltip("The player's rigidbody")]
    [SerializeField] Rigidbody playerRigidbody;

    [Tooltip("The player's model")]
    [SerializeField] MeshRenderer playerModel;

    [Tooltip("The audio player that plays the death sound")]
    [SerializeField] AudioSource deathAudio;

    [Tooltip("Is this DeathHandler checking if the player dies when they stand on something?")]
    [SerializeField] bool isGroundCheck;

    float killzone; // The Y level kill zone cached from LevelData

    // Cache the kill level
    void Start()
    {
        killzone = LevelData.Instance.yLevelKillzone;
    }

    void FixedUpdate()
    {
        if(transform.position.y <= killzone)
        {
            StartCoroutine(KillPlayer());
        }
    }

    // If player hits a non-safe object, send them back to the start of the level
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3 && isGroundCheck || other.gameObject.layer == 6 || other.gameObject.layer == 7) { return; } // As hitting most objects in the game should kill the player, marking the safe objects to touch makes more sense

        StartCoroutine(KillPlayer());
    }

    // Coroutine to actually kill the player
    public IEnumerator KillPlayer()
    {
        // Hide player and stop them from moving
        playerModel.enabled = false;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(LevelManager.Instance.musicSpeaker);

        deathAudio.Play();

        // Short break between attempts
        yield return new WaitForSeconds(2);

        // Reload level
        LevelManager.Instance.levelAttempt += 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
