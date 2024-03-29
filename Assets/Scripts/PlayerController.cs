﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	AudioSource jump;
	AudioSource pickup;

	public string menu;

	public float moveSpeed;
	private float moveSpeedStore;

	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;

	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;

	private Rigidbody2D myRigidbody;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	//private Collider2D myCollider;

	private Animator myAnimator;

	public GameManager theGameManager;

	// Use this for initialization
	void Start () {

		AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
		jump = allMyAudioSources [1];
		pickup = allMyAudioSources [0];

		myRigidbody = GetComponent<Rigidbody2D>();

		myAnimator = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

			moveSpeed = moveSpeed * speedMultiplier;
		}


		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			if (grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jump.Play ();
		
			}
		}
		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) {
			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			jumpTimeCounter = 0;
		}
		if (grounded) {
			jumpTimeCounter = jumpTime;
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "killbox") {
			Application.LoadLevel (menu);
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
		}

	}

}
