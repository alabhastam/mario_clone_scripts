using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int coinsToCollect = 20; // Set the number of coins required to load the next level
    private ScoreScript scoreScript;

    void Start()
    {
        // Find the ScoreScript in the scene
        scoreScript = FindObjectOfType<ScoreScript>();
    }

    void Update()
    {
        // Check if the player has collected the required number of coins
        if (scoreScript.GetCoinCount() >= coinsToCollect)
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("Gameplay4"); // Replace with your next level scene name
    }
}
