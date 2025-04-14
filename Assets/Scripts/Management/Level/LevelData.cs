using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    // Stores important per-level information

    [Tooltip("The starting position of the level")]
    public Transform startPos;

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
}
