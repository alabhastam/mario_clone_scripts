using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour

{
    private Animator anim;
    private Rigidbody2D myBody;
    private Vector3 moveDirection = Vector3.down; //initail direction
    private string coroutine_name = "ChangeMovement";
     void Awake() {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        StartCoroutine(coroutine_name);
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpider();
    }
    void MoveSpider(){
        transform.Translate(moveDirection * Time.smoothDeltaTime);
    }
    IEnumerator ChangeMovement(){
        yield return new WaitForSeconds(Random.Range(2f,5f));
        if (moveDirection == Vector3.down){
            moveDirection = Vector3.up;
        }
        else{
            moveDirection = Vector3.down;
        }
        StartCoroutine(coroutine_name);

    }
    // I wrote function below for killing object then I used it in next function.
    IEnumerator SpiderDead(){
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
     void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == Tags.BULLET_TAG){
            anim.Play("SpiderDead");
            myBody.bodyType = RigidbodyType2D.Dynamic;

            StartCoroutine(SpiderDead());
            StopCoroutine(coroutine_name);

        }
        if(target.tag ==Tags.PLAYER_TAG){
            target.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
    }
}
