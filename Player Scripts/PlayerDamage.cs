using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    private Text lifeText;
    private int lifeScoreCount;
    private bool canDamage; 


    //life not score
    public ScoreScript scoreScript;
    
    void Start() {
        Time.timeScale = 1f;    
    }
    void Awake() {
        lifeText =GameObject.Find("LifeText").GetComponent<Text>();
        lifeScoreCount = 3 ; 
        lifeText.text = "x" + lifeScoreCount;

        canDamage = true;
        //life not score
        scoreScript = GameObject.FindObjectOfType<ScoreScript>();
    }
    

    public void DealDamage(){
        if(canDamage){
            lifeScoreCount--;

            if(lifeScoreCount >= 0){
                lifeText.text = "x" + lifeScoreCount; 

            }
            if(lifeScoreCount == 0){
                if (scoreScript != null && scoreScript.GetCoinCount() > 0) {
                    // استفاده از سکه‌ها برای یک ضربه اضافی
                    scoreScript.SetCoinCount(0);
                    lifeScoreCount = 1;
                    lifeText.text = "x" + lifeScoreCount;
                }else{
                Time.timeScale = 0f;
                StartCoroutine(RestartGame());
                }
            }

            canDamage = false;

            StartCoroutine(WaitForDamage());
        }
        
    }



    IEnumerator WaitForDamage(){
        // time.timescale up in the page ws depend on this function then we cant use normal wait for sec
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    IEnumerator RestartGame(){
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Gameplay");
    }
}
