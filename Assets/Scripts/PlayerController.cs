using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rbody;

    public bool grounded;
    public LayerMask isGround;

    private Collider2D myCollider;

    private Animator myAnimator;

	// Use this for initialization
	void Start () {

        rbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, isGround);

        rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {

            if(grounded) { rbody.velocity = new Vector2(rbody.velocity.x, jumpForce); }            
        }

        myAnimator.SetFloat("Speed", rbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
	}
}
