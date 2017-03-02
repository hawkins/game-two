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

	public int modifier;	// The current modifier
	public int baseInc;		// The base amount the score increases per avoided obstacle
	public int adj;			// How much getting a mushroom or pill

	private Animator myAnimator;

	private Collider2D myCollider;
    
	private Rigidbody2D rbody;

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		SetScoreText ();
        rbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

	}

	void Update() {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        grounded = Physics2D.IsTouchingLayers(myCollider, isGround);

        rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {

            if(grounded) { rbody.velocity = new Vector2(rbody.velocity.x, jumpForce); }            
        }

        myAnimator.SetFloat("Speed", rbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
	}

	void OnTriggerEnter(Collider other) {
		// if (other.gameObject.CompareTag("Pass") {
		// score += (baseInc - modifier);
		// } else if (other.gameObject.CompareTag("Mushroom") {
		// baseInc -= modifier;
		// } else if (other.gameObject.CompareTag("Pill") {
		// baseInc += modifier;
		// }
		// SetScoreText();
	}

	void SetScoreText() {
		scoreText.text = "Score: " + score.ToString ();
	}
}
