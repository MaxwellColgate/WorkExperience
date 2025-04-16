using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLevelSelector : MonoBehaviour
{
    // Opens and closes the level selector menu

    [Tooltip("The level selector menu")]
    [SerializeField] GameObject levelSelectorMenu;

    // Close the level selector if the user presses escape
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseLevelSelector();
        }
    }

    // Open the level selector
    public void OpenLevelSelector()
    {
        levelSelectorMenu.SetActive(true);
    }

    // Close the level selector
    public void CloseLevelSelector()
    {
        levelSelectorMenu.SetActive(false);
    }
}
