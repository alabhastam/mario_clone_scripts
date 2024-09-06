using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScripts : MonoBehaviour
{
    // Method to start the game by loading the Gameplay scene
    public void PlayGame()
    {
        PlayerPrefs.SetInt("PlayerLives", PlayerDamage.defaultHealth);
        PlayerPrefs.Save(); 
        SceneManager.LoadScene("Gameplay");
    }

    // Method to load the settings scene
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    // Method to exit the game
    public void ExitGame()
    {
        // If running in the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running in a build
        Application.Quit();
#endif
    }
}