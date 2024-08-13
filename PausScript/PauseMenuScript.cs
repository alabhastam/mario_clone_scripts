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
        Time.timeScale = 1f; // Ensure the game is unpaused
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
