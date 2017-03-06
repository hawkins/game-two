using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public LayerMask isGround;

	public Text scoreText;

	public bool grounded;
	public float moveSpeed;
    public float jumpForce;
	public int baseInc;		// The base amount the score increases per avoided obstacle

	private Animator myAnimator;

	private Collider2D myCollider;
    
	private Rigidbody2D rbody;

	private bool alive;
	private float adj;		// How much getting a mushroom or pill affects the modifier
	private float modifier;	// The current time modifier
	private float score;
	private float high_score;

	// Use this for initialization
	void Start () {
		PlayerPrefs.GetFloat ("highscore");
		score = 0.0f;
		modifier = 0.2f;
		adj = 0.05f;
		alive = true;
		SetScoreText ();
		InvokeRepeating ("UpdateScore", 0.0f, 1.0f);	// Repeats UpdateScore every second
		rbody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();

	}

	void UpdateScore() {
		score += modifier * baseInc;
		SetScoreText ();
		if (score > high_score && !alive) {
			high_score = score;
			PlayerPrefs.SetFloat ("highscore", high_score);
			Debug.Log ("High Score: " + high_score);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.IsTouchingLayers (myCollider, isGround);
		rbody.velocity = new Vector2 (moveSpeed, rbody.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			if (grounded) {
				rbody.velocity = new Vector2 (rbody.velocity.x, jumpForce);
			}
		}

		myAnimator.SetFloat ("Speed", rbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	}

	void OnTriggerEnter(Collider other) {
		// if (other.gameObject.CompareTag("Pass") {
		// score += baseInc;
		// } else if (other.gameObject.CompareTag("Mushroom") {
		// modifier -= adj;
		// } else if (other.gameObject.CompareTag("Pill") {
		// modifer += adj;
		// if (abs(modifier) < 0.01f) {
		// alive = false;
		// }
		// }
		// SetScoreText();
	}

	void SetScoreText() {
		scoreText.text = "Score: " + score.ToString ();
	}
}
