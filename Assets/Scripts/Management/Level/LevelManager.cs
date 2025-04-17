using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Stores data that needs to persist across level attempts and manages level tasks

    [Header("References")]

    [Tooltip("The player prefab")]
    [SerializeField] GameObject playerPref;

    [Tooltip("The music speaker prefab")]
    [SerializeField] GameObject musicSpeakerPref;

    [Header("Data")]

    [Tooltip("How many times the player has attempted the level")]
    public int levelAttempt = 1;

    [Tooltip("The current spawn point being used in LevelData's spawnPos array")]
    public int currentSpawn = 0;

    [Header("Level objects")]

    [Tooltip("The player object instantiated in the level")]
    public GameObject player;

    [Tooltip("The speaker that is currently playing music in the level")]
    public GameObject musicSpeaker;

    public static event Action<int, AudioSource> StartingFromCheckpoint; // Notifies checkpoints if we are starting from a checkpoint

    public static LevelManager Instance { get; private set; }

    // Tracks which checkpoints have been triggered (by their ID)
    public HashSet<int> TriggeredCheckpoints = new HashSet<int>();


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

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += ActivateLevelSelectMenu;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= ActivateLevelSelectMenu;
    }

    //Start the level when called by LevelData
    public void StartLevel()
    {
        Transform spawnTransform = LevelData.Instance.spawnPos[currentSpawn];

        player = Instantiate(playerPref, spawnTransform.position, spawnTransform.rotation);
        player.GetComponent<Movement>().forwardforce = LevelData.Instance.levelSpeed;

        musicSpeaker = Instantiate(musicSpeakerPref, spawnTransform.position, spawnTransform.rotation);
        musicSpeaker.GetComponent<FollowPlayer>().player = player.transform;

        AudioSource musicSource = musicSpeaker.GetComponent<AudioSource>(); // Cache the player's speaker because we use it more than once
        musicSource.clip = LevelData.Instance.levelMusic;

        // If starting from checkpoint, notify checkpoints so they can set the music's point
        if(currentSpawn != 0)
        {
            StartingFromCheckpoint.Invoke(currentSpawn, musicSource);
        }

        musicSource.Play();
    }

    // If the player leaves the level, auto open the level select menu and then destroy this object
    public void ActivateLevelSelectMenu(Scene current, Scene next)
    {
        if(next.name == "MainMenu")
        {
            ManageLevelSelector levelSelectScreen = GameObject.FindGameObjectWithTag("LevelSelectMenu").GetComponent<ManageLevelSelector>();
            levelSelectScreen.OpenLevelSelector();
            Destroy(gameObject);
        }
    }
}
