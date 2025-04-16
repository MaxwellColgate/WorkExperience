using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelectController : MonoBehaviour
{
    // Changes the information about a level on the selector screen based on information provided by the LevelCompiler

    [Tooltip("The level icon image")]
    [SerializeField] Image levelIcon;

    [Tooltip("The level title text")]
    [SerializeField] TextMeshProUGUI levelTitle;

    [Tooltip("The level difficulty text")]
    [SerializeField] TextMeshProUGUI levelDifficultyText;

    [Tooltip("The level credit text")]
    [SerializeField] TextMeshProUGUI levelCredit;

    [Tooltip("The mark that appears on a level once you've completed it")]
    [SerializeField] GameObject completionMark;

    [Tooltip("The level's scene")]
    Scene levelScene;

    // Set's the levels title, must be the same name as the scene name
    public void SetLevelTitle(string title)
    {
        levelTitle.text = title;
    }

    // Set the level's icon
    public void SetLevelIcon(Sprite icon)
    {
        levelIcon.sprite = icon;
    }

    // Set the level's difficulty
    public void SetLevelDifficulty(string difficulty)
    {
        levelDifficultyText.text = difficulty;
    }

    // Set the level's credits
    public void SetLevelCredits(string credit)
    {
        levelCredit.text = credit;
    }

    // If the player has completed this level before, activate the completion marker
    public void ActivateCompletionMark()
    {
        completionMark.SetActive(true);
    }

    public void OpenLevel()
    {
        if(levelScene == null) { Debug.Log("Failed to load level, no scene is set!"); return; }
        SceneManager.LoadSceneAsync(levelTitle.text);
    }
}
