using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private Animator anim;

    private bool animation_Started;
    private bool animation_Finished;
    private int jumpedTimes;
    private bool jumpLeft= true;

    private string coroutine_name = "FrogJump"; 
     void Awake() {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(coroutine_name); 
    }

    // Update is called once per frame
    void Update()
    {
        if (animation_Started && animation_Finished){
            animation_Started = false;
            // these two line of code make animation independent from its position.
            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }

    IEnumerator FrogJump(){
        yield return new WaitForSeconds(Random.Range(1f,4f));
        animation_Started = true;
        animation_Finished = false; 

        if(jumpLeft){
            anim.Play("FrogJumpLeft");
        }
        else{
            // we will complete this line if we conclude its fair for player 
            anim.Play("FrogJumpRight");
        }
        StartCoroutine(coroutine_name);
    }
    //this one involved with events in animation panel
    void AnimationFinished(){
        animation_Finished = true; 
        anim.Play("FrogIdleLeft");
    }
}
