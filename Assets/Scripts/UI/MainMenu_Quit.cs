using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Quit : MonoBehaviour
{
    public void QuitGame() 
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
