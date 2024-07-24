using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Animator anim; 
    private int health = 2; // You can adjust this for testing purposes

    private bool canDamage; 

    void Awake() {
        anim = GetComponent<Animator>();
        canDamage = true; 
    }

    IEnumerator WaitForDamage(){
        yield return new WaitForSeconds(2f);
        canDamage = true; 
    }

    void OnTriggerEnter2D(Collider2D target){
       Debug.Log("Collision Detected with: " + target.tag);
        if(target.tag == "Bullet"){
            Debug.Log("Hit by bullet");
            if(canDamage){
                health--;
                Debug.Log("Boss health: " + health);
                canDamage = false;

                if(health == 0 ){
                    Debug.Log("Boss is dead");
                    GetComponent<BossScript>().DeactivateBossScript(); 
                    anim.Play("BossDead");
                    // Optionally destroy the boss game object after the animation plays
                    Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length); 
                }
            }
            StartCoroutine(WaitForDamage());
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
