using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Stores data that needs to persist across level attempts and manages level tasks

    [Header("References")]

    [Tooltip("The player prefab")]
    [SerializeField] GameObject playerPref;

    [Header("Data")]

    [Tooltip("How many times the player has attempted the level")]
    public int levelAttempt = 1;

    [Tooltip("The current spawn point being used in LevelData's spawnPos array")]
    public int currentSpawn = 0;

    public static LevelManager Instance; //{ get; private set; }

    // Set up singleton
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //Start the level when called by LevelData
    public void StartLevel()
    {
        GameObject player = Instantiate(playerPref, LevelData.Instance.spawnPos[currentSpawn].position, Quaternion.identity);
        player.GetComponent<AudioSource>().clip = LevelData.Instance.levelMusic;
    }
}
