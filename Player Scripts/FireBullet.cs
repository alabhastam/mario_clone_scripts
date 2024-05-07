using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    private float speed = 10f; 
    private Animator anim;
    private bool canMove;
    void Awake() {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        canMove = true;
        StartCoroutine (DisableBullet(5f));
    }

    void Update()
    {
        Move();
    }

    void Move (){
        if(canMove){
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
    }
    public float Speed{
        get {
            return speed;
        }
        set {
            speed = value;
        }
    }
    IEnumerator DisableBullet(float timer){
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D target) {
        //that prevent sharoon enemy
        if (target.gameObject.tag == Tags.BETTLE_TAG || target.gameObject.tag == Tags.SNAIL_TAG
           || target.gameObject.tag == Tags.SPIDER_TAG || target.gameObject.tag ==Tags.BOSS_TAG ){
            anim.Play("Explode");
            canMove = false;
            StartCoroutine (DisableBullet(0.2f)); 
        }
    }
}
