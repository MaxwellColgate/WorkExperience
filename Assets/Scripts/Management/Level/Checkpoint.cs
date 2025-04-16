using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
    {
        public int checkpointID;

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