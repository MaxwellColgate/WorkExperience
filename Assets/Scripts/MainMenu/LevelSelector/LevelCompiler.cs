using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompiler : MonoBehaviour
{
    // Compiles all levels in Levels folder to show on level select screen

    [Tooltip("A list of every available level")]
    [SerializeField] List<LevelMetadata> levels = new List<LevelMetadata>();

    [Tooltip("The template level selection notif")]
    [SerializeField] GameObject levelSelectPref;

    [SerializeField] Transform levelSelectRoot;

    // Find all levels and generate the selection
    void Awake()
    {
        int currentLevel = 1;

        foreach(LevelMetadata level in levels)
        {
            Vector3 levelSpawn = new Vector3(levelSelectRoot.position.x + 50 * currentLevel, levelSelectRoot.position.y, levelSelectRoot.position.z);
            GameObject newLevel = Instantiate(levelSelectPref, levelSpawn, Quaternion.identity, levelSelectRoot);
            SetLevelInfo(level, newLevel);
        }
    }

    // Sets the level selector's information on the level select screen
    void SetLevelInfo(LevelMetadata levelData, GameObject levelSelector)
    {
        LevelSelectController levelController = levelSelector.GetComponent<LevelSelectController>();

        levelController.SetLevelTitle(levelData.levelName); // Sets the levels scene and title, these need to be the same
        levelController.SetLevelIcon(levelData.levelIcon); // Set the level's icon
        levelController.SetLevelDifficulty("Difficulty: " + levelData.levelDifficulty); // Set the level's difficulty

        if(levelData.previouslyBeaten == true) { levelController.ActivateCompletionMark(); }

        string compiledCredits = ""; // Store the compiled credits in a string

        // Compile all credits in the levelCredits list into one string, with a new line in-between every credit that isn't the first
        for(int i = 0; i < levelData.levelCredits.Count; i++)
        {
            if(i != 0) { compiledCredits += "\n"; }
            compiledCredits += levelData.levelCredits[i];
        }
        levelController.SetLevelCredits(compiledCredits);
    }
}
