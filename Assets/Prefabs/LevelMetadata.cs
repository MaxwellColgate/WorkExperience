using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level Metadata", menuName = "Level/Level Metadata", order = 1)]
public class LevelMetadata : ScriptableObject
{
    // Metadata stored for each level

    [Tooltip("This level's icon")]
    public Sprite levelIcon;

    [Tooltip("This level's name, needs to be the same as the level's scene name")]
    public string levelName;

    [Tooltip("This level's difficulty")]
    public string levelDifficulty;

    [Tooltip("The credits attributed to this level")]
    public List<string> levelCredits = new List<string>();

    [Tooltip("If the player has previously beaten this level")]
    public bool previouslyBeaten;
}
