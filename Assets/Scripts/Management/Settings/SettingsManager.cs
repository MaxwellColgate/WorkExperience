using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Handles storing and changing settings

    [Tooltip("The default target FPS")]
    [SerializeField] int defaultFPS = 60;

    public static SettingsManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SetTargetFramerate(defaultFPS);
    }

    // Changes the target FPS
    public void SetTargetFramerate(int target)
    {
        Application.targetFrameRate = target;
    }
}
