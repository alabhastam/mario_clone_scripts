using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    private Text lifeText;
    private int lifeScoreCount;
    private bool canDamage;

    public ScoreScript scoreScript;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Awake()
    {
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();

        // Load the player's life count from PlayerPrefs (default is 3 if not set)
        lifeScoreCount = PlayerPrefs.GetInt("PlayerLives", 10);
        lifeText.text = "x" + lifeScoreCount;

        canDamage = true;
        scoreScript = GameObject.FindObjectOfType<ScoreScript>();
    }

    public void DealDamage()
    {
        if (canDamage)
        {
            lifeScoreCount--;

            // Update and save the player's life count every level
            PlayerPrefs.SetInt("PlayerLives", lifeScoreCount);
            PlayerPrefs.Save();

            if (lifeScoreCount >= 0)
            {
                lifeText.text = "x" + lifeScoreCount;
            }

            if (lifeScoreCount == 0)
            {
                if (scoreScript != null && scoreScript.GetCoinCount() > 0)
                {
                    scoreScript.SetCoinCount(0);
                    lifeScoreCount = 1;
                    PlayerPrefs.SetInt("PlayerLives", lifeScoreCount);
                    PlayerPrefs.Save();
                    lifeText.text = "x" + lifeScoreCount;
                }
                else
                {
                    Time.timeScale = 0f;
                    StartCoroutine(RestartGame());
                }
            }

            canDamage = false;
            StartCoroutine(WaitForDamage());
        }
    }

    public int GetLifeCount()
    {
        return lifeScoreCount;
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        PlayerPrefs.DeleteKey("PlayerLives"); // Reset lives when restarting the game
        SceneManager.LoadScene("Gameplay");
    }
}
