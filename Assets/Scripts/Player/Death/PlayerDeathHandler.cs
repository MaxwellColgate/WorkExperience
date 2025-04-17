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

    bool alreadyDied; // Ensure player only dies once

    // Cache the kill level
    void Start()
    {
        killzone = LevelData.Instance.yLevelKillzone;
    }

    void FixedUpdate()
    {
        if(transform.position.y <= killzone && !alreadyDied)
        {
            StartCoroutine(KillPlayer());
        }
    }

    // If player hits a non-safe object, send them back to the start of the level
    void OnTriggerEnter(Collider other)
    {
        // Don't kill player if they touch safe objects
        switch (other.gameObject.layer){
            case 3:
                if (isGroundCheck) { return; }
                break;
            case 6:
                return;
            case 7:
                return;
            default:
                break;
        }
        if (alreadyDied) { return; }

        StartCoroutine(KillPlayer());
    }

    // Coroutine to actually kill the player
    public IEnumerator KillPlayer()
    {
        alreadyDied = true;

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
