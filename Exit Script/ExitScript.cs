using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Flag : MonoBehaviour
{
    public string nextSceneName;
    
    
    public AudioSource levelClearSound; 

    private bool levelCompleted = false; // To avoid multiple triggers

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !levelCompleted)
        {
            levelCompleted = true; 

            // Play the level clear sound
            if (levelClearSound != null)
            {
                levelClearSound.Play(); 
            }

            // Delay scene load to allow the sound to play
            StartCoroutine(LoadNextSceneWithDelay(2f)); 
        }
    }

    
    IEnumerator LoadNextSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName); 
    }
}
