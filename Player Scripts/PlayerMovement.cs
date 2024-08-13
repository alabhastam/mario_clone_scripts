using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private bool isPaused = false;

    public float speed = 5f;
    private Rigidbody2D myBody;
    private Animator anim;
    private bool isGrounded;
    private bool jumped;
 
    private float jumpPower = 14f;

    public Transform groundCheckPosition; 
    public LayerMask groundLayer; 

    void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update(){

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        CheckIfGrounded();
        PlayerJump();

    }

    void FixedUpdate()
    {
        PlayerWalk();

        
    }

    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h>0){
            myBody.velocity = new Vector2 (speed, myBody.velocity.y);  

            ChangeDirection(1);
        }
        else if (h<0){
            myBody.velocity = new Vector2 (-speed, myBody.velocity.y);

            ChangeDirection(-1);
        }
        else{
            myBody.velocity = new Vector2 (0f, myBody.velocity.y);
        }
        anim.SetInteger("Speed",Mathf.Abs((int)myBody.velocity.x));

    }

    void ChangeDirection (int direction){
        Vector3 tempScale  = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    void CheckIfGrounded(){
        isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer);
        if (isGrounded){
            if(jumped){
                jumped = false ;
                anim.SetBool ("Jump", false) ;
            }
        }
    }
    void PlayerJump (){
        if (isGrounded){
            if(Input.GetKey(KeyCode.Space)){
                jumped = true; 
                myBody.velocity = new Vector2 (myBody.velocity.x, jumpPower);
                anim.SetBool("Jump", true);
            }
        }
    }
    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the gameplay
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive); // Load PauseMenu scene additively
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the gameplay
        SceneManager.UnloadSceneAsync("PauseMenu"); // Unload the PauseMenu scene
    }
}