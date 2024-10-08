using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour {

	private Coroutine changeDirectionCoroutine;
	public float moveSpeed = 1.5f;
	private Rigidbody2D myBody;
	private Animator anim;

	public LayerMask playerLayer;

	private bool moveLeft;

	private bool canMove;
	private bool stunned;

	
	public Transform left_Collision, right_Collision, top_Collision, down_Collision;
	private Vector3 left_Collision_Pos, right_Collision_Pos;

	void Awake() {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		left_Collision_Pos = left_Collision.position;
		right_Collision_Pos = right_Collision.position;
	}

	void Start () {
		moveLeft = true;
		canMove = true;
		changeDirectionCoroutine = StartCoroutine(ChangeDirectionRoutine());

		
	}

	//change enemy direction with random time
	private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            ChangeDirection();
        }
    }
	// Stop the coroutine if the object is destroyed or no longer needed
    void OnDestroy()
    {
        if (changeDirectionCoroutine != null)
        {
            StopCoroutine(changeDirectionCoroutine);
        }
    }

	void Update () {
		if (canMove) {
			if (moveLeft) {
				myBody.velocity = new Vector2 (-moveSpeed, myBody.velocity.y);
			} else {
				myBody.velocity = new Vector2 (moveSpeed, myBody.velocity.y);
			}
		}

		CheckCollision ();

	}

	void CheckCollision() {

		RaycastHit2D leftHit = Physics2D.Raycast (left_Collision.position, Vector2.left, 0.1f, playerLayer);
		RaycastHit2D rightHit = Physics2D.Raycast (right_Collision.position, Vector2.right, 0.1f, playerLayer);
		Debug.DrawRay(left_Collision.position, Vector2.left * 0.1f, Color.red);
		Debug.DrawRay(right_Collision.position, Vector2.right * 0.1f, Color.red);

		Collider2D topHit = Physics2D.OverlapCircle (top_Collision.position, 0.2f, playerLayer);

		if (topHit != null) {
			if (topHit.gameObject.tag == Tags.PLAYER_TAG) {
				if (!stunned) {
					// player has jump effect when jump at snail 
					topHit.gameObject.GetComponent<Rigidbody2D> ().velocity =
						new Vector2 (topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);

					canMove = false;
					myBody.velocity = new Vector2 (0, 0);

					anim.Play ("Stunned");
					stunned = true;

					// BEETLE CODE HERE
					if(tag == Tags.BETTLE_TAG) {
						anim.Play ("Stunned");
						StartCoroutine (Dead (0.5f));
					}
				}
			}
		}

		if (leftHit) {
			if (leftHit.collider.gameObject.tag == Tags.PLAYER_TAG) {
				if (!stunned) {
					// APPLY DAMAGE TO PLAYER
					leftHit.collider.gameObject.GetComponent<PlayerDamage>().DealDamage();
				} else {
					//this should only happen for snail not beetle
					if (tag != Tags.BETTLE_TAG) {
						//myBody.velocity = new Vector2 (15f, myBody.velocity.y);
						//used to be a way for pushing fast for snail 
						StartCoroutine (Dead (3f));
					}
				}
			}
		}

		if (rightHit) {
			if (rightHit.collider.gameObject.tag == Tags.PLAYER_TAG) {
				if (!stunned) {
					// APPLY DAMAGE TO PLAYER
					rightHit.collider.gameObject.GetComponent<PlayerDamage>().DealDamage();
				} else {
					//this should only happen for snail not beetle
					if (tag != Tags.BETTLE_TAG) {
						//myBody.velocity = new Vector2 (-15f, myBody.velocity.y);
						//used to be a way for pushing fast for snail 
						StartCoroutine (Dead (3f));
					}
				}
			}
		}

		// IF we don't detect collision any more do whats in {}
		if (!Physics2D.Raycast (down_Collision.position, Vector2.down, 0.1f)) {

			//ChangeDirection ();
			//Debug.Log("direction change");
		}

	}
	//we dont use this func . we have Routine instead

void ChangeDirection() {
    if (stunned) {
        return; 
    }

    moveLeft = !moveLeft;

    Vector3 tempScale = transform.localScale;

    if (moveLeft) {
        tempScale.x = Mathf.Abs(tempScale.x); 
    } else {
        tempScale.x = -Mathf.Abs(tempScale.x);  
    }

    transform.localScale = tempScale;  
}



	IEnumerator Dead(float timer) {
		yield return new WaitForSeconds (timer);
		gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == Tags.BULLET_TAG) {

			if (tag == Tags.BETTLE_TAG) {
				anim.Play ("Stunned");

				canMove = false;
				myBody.velocity = new Vector2 (0, 0);

				StartCoroutine (Dead (0.4f));
			}

			if (tag == Tags.SNAIL_TAG) {
				if (!stunned) {
					
					anim.Play ("Stunned");
					stunned = true;
					canMove = false;
					myBody.velocity = new Vector2 (0, 0);

				} else {
					gameObject.SetActive (false);
				}
			}

		}
	}

} // class

