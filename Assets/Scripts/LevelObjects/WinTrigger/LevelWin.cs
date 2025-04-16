using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    // Handles winning the game!

    [Tooltip("The players")]
    [SerializeField] GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player") { return; }

        winScreen.SetActive(true);
        other.gameObject.SetActive(false);
    }

    // Restart the level
    public void RetryLevel()
    {
        string currentLevelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(currentLevelName);
    }

    // Quit back to the level select menu
    public void QuitLevel()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
