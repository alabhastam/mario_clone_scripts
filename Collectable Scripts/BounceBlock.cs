using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BounceBlock : MonoBehaviour
{
    public Transform bottom_Collision;
    public Animator anim; 
    public LayerMask playerLayer;

    private Vector3  moveDirection =  Vector3.up;
    private Vector3 oroginPosition;
    private Vector3 animPosition;
    private bool startAnim; 
    private bool canAnimate = true;     

    void Awake() {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        oroginPosition = transform.position;
        animPosition = transform.position;
        animPosition.y += 15f; 
    }

    // Update is called once per frame
    void Update()
    {
        CheckForCollision();
        //UpDownAnim();
        //its broken for some reson check that later 
    }
    void CheckForCollision(){
        if(canAnimate){
            RaycastHit2D hit = Physics2D.Raycast(bottom_Collision.position,Vector2.down,0.1f,playerLayer);
            if (hit){
                if(hit.collider.gameObject.tag == Tags.PLAYER_TAG){
                    // sth good will happen later with that : like score or .. 
                    anim.Play("BlockEmpty");
                    startAnim = true; 
                    canAnimate = false; 
            }
        }
        }
    }
    void UpDownAnim(){
        if(startAnim){
            transform.Translate(moveDirection * Time.smoothDeltaTime);

            if(transform.position.y >= animPosition.y){
                moveDirection = Vector3.down;                                               
            }
            else if(transform.position.y <= oroginPosition.y){
                startAnim = false;
            }
        }
    }
}
///next time you came back need to add some more function to bounce block
