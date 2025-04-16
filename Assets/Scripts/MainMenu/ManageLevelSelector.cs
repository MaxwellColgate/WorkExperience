using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLevelSelector : MonoBehaviour
{
    // Opens and closes the level selector menu

    [Tooltip("The level selector menu")]
    [SerializeField] GameObject levelSelectorMenu;
    
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
