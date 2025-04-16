using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        GameObject player = Instantiate(playerPref, LevelData.Instance.spawnPos[currentSpawn].position, Quaternion.identity);
        player.GetComponent<Movement>().forwardforce = LevelData.Instance.levelSpeed;
        player.GetComponent<AudioSource>().clip = LevelData.Instance.levelMusic;    
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
