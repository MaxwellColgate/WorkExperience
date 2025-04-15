using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    // Stores per-level information that stays the same across level attempts

    [Header("References")]

    [Tooltip("This level's music")]
    public AudioClip levelMusic;

    [Tooltip("How fast this level is")]
    public float levelSpeed = 2;

    [Tooltip("An ordered list of every spawn point in the level")]
    public Transform[] spawnPos;

    [Tooltip("The minimum height of the level, they player dies if they reach this point")]
    public float yLevelKillzone;

    public static LevelData Instance { get; private set; }

    // Set up singleton
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Debug.Log("Multiple LevelData's exist! deleting newest...");
            Destroy(gameObject);
        }
        Instance = this;
    }

    // When the level loads, either when starting for the first time or on death, start the level
    void Start()
    {
        LevelManager.Instance.StartLevel();
    }
}
