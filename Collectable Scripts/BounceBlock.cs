using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBlock : MonoBehaviour
{
    public Transform bottom_Collision;
    public LayerMask playerLayer;
    public ScoreScript scoreScript;

    private Vector3 moveDirection = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animPosition;
    private bool startAnim;
    private bool canAnimate = true;

    void Start()
    {
        originPosition = transform.position;
        animPosition = transform.position;
        animPosition.y += 0.15f; // Adjust as needed
    }

    void Update()
    {
        CheckForCollision();
        UpDownAnim();
    }

    void CheckForCollision()
    {
        if (canAnimate)
        {
            RaycastHit2D hit = Physics2D.Raycast(bottom_Collision.position, Vector2.down, 0.1f, playerLayer);
            if (hit)
            {
                if (hit.collider.gameObject.tag == Tags.PLAYER_TAG)
                {
                    // Play animation code here if you need it
                    startAnim = true;
                    canAnimate = false;
                    if (scoreScript != null)
                    {
                        scoreScript.AddScore(3); // Add 3 score for hitting the bounce block
                    }
                }
            }
        }
    }

    void UpDownAnim()
    {
        if (startAnim)
        {
            transform.Translate(moveDirection * Time.deltaTime);
            if (transform.position.y >= animPosition.y)
            {
                moveDirection = Vector3.down;
            }
            else if (transform.position.y <= originPosition.y)
            {
                startAnim = false;
                moveDirection = Vector3.up;
            }
        }
    }
}
