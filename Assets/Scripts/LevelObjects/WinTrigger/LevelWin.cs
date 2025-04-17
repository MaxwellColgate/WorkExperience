using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelWin : MonoBehaviour
{
    // Handles winning the game!

    [Tooltip("The win screen")]
    [SerializeField] GameObject winScreen;

    [Tooltip("The attempt text on the win screen")]
    [SerializeField] TextMeshProUGUI attemptText;

    // If the player touches the win trigger, activate the win sequence
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player") { return; }

        if (LevelManager.Instance.levelAttempt == 1) { attemptText.text = "First try!!"; }
        else { attemptText.text = "Attempts: " + LevelManager.Instance.levelAttempt; }
        
        winScreen.SetActive(true);
        other.gameObject.SetActive(false);
    }

    // Restart the level
    public void RetryLevel()
    {
        Destroy(LevelManager.Instance.gameObject);
        string currentLevelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(currentLevelName);
    }

    // Quit back to the level select menu
    public void QuitLevel()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
