using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScipt : MonoBehaviour
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
            scoreCount++;

            coinTextScore.text = "x" + scoreCount;
            audioManager.Play();
        }
    }
}
