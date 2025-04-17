using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointID = 1;

    [Tooltip("The point in the song (in seconds) that should be skipped to when starting from this checkpoint")]
    public float musicTime;

    private void OnEnable()
    {
        LevelManager.StartingFromCheckpoint += SkipMusic;
    }

    private void OnDisable()
    {
        LevelManager.StartingFromCheckpoint -= SkipMusic;
    }

    // If starting from this checkpoint, skip music to where it would be if we made it here from the start of the level
    public void SkipMusic(int currentCheckpoint, AudioSource playerSpeaker)
    {
        if(currentCheckpoint != checkpointID) { return; }
        playerSpeaker.time = musicTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (LevelManager.Instance != null)
            {
                // Only trigger if this checkpoint hasn't been used yet
                if (!LevelManager.Instance.TriggeredCheckpoints.Contains(checkpointID))
                {
                    LevelManager.Instance.currentSpawn += 1;
                    LevelManager.Instance.TriggeredCheckpoints.Add(checkpointID);
                    Debug.Log("Checkpoint triggered! New spawn point index: " + LevelManager.Instance.currentSpawn);
                }
            }
            else
            {
                Debug.LogWarning("LevelManager instance not found!");
            }
        }
    }
}