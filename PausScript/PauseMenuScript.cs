using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public void ContinueGame()
    {
        SceneManager.UnloadSceneAsync("PauseMenu"); // Unload the PauseMenu scene
        Time.timeScale = 1f; // Resume the game
    }

    public void LoadMainMenu()
    {
        ResetPlayerHealth();
        Time.timeScale = 1f; // Ensure the game is unpaused
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        ResetPlayerHealth();
        Application.Quit();
    }
    private void ResetPlayerHealth()
    {
        PlayerPrefs.SetInt("PlayerLives", 10); // Reset health to default (10 or any value you prefer)
        PlayerPrefs.Save(); // Save the changes
    }
}
