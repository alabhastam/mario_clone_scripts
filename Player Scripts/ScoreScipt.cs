using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text coinTextScore; 
    private AudioSource audioManager;
    private int scoreCount = 0;

    void Awake() {
        audioManager = GetComponent<AudioSource>();
    }

    void Start()
    {
        coinTextScore = GameObject.Find("CoinText").GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == Tags.COIN_TAG){
            target.gameObject.SetActive(false);
            AddScore(1);
        }
    }

    public void AddScore(int amount) {
        scoreCount += amount;
        coinTextScore.text = "x" + scoreCount;
        audioManager.Play();
    }

    public int GetCoinCount() {
        return scoreCount;
    }

    public void SetCoinCount(int count) {
        scoreCount = count;
        coinTextScore.text = "x" + scoreCount;
    }
}
