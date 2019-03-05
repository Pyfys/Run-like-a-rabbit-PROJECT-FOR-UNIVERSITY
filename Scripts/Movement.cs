using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    
    public float jumpSpeed;
    private float jumpCounter;
    public float jumpTime;

    public LayerMask ground;
    public float downSpeed;
    public Transform groundCheck;
    public float groundCheckRadius;

    private bool stoppedJumping;

    private Rigidbody2D rigidbody;
    private bool grounded;
    private Collider2D collider;

    public GameTrigger theGameManager;

    private Animator myAnimator;

	// Use this for initialization
	void Start () {

        rigidbody = GetComponent<Rigidbody2D>();

        collider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        jumpCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        stoppedJumping = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
  
            speed = speed * speedMultiplier;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground); 

        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        

        if (Input.GetKeyDown(KeyCode.S))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, downSpeed);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
                stoppedJumping = false;
            }
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !stoppedJumping)
        {
            if (jumpCounter > 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
                jumpCounter -= Time.deltaTime;
            }
        }

        if (grounded)
        {
            jumpCounter = jumpTime;
        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            jumpCounter = 0;
            stoppedJumping = true;
        }


        myAnimator.SetFloat("Speed", rigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);

	}
    void OnCollisionEnter2D(Collision2D platform)
    {
        if (platform.gameObject.tag == "death")
        {
            theGameManager.RestartGame();
        }
    }
}
