using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerJump : MonoBehaviour
{
    // Force, apply force, 1x
    // rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    [Header("Jump Details")]
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;
    
    [Header ("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whaIsGround;
    public bool grounded;

    [Header("Components")]
    private Rigidbody2D rb;
    private Animator myAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
    }
    //myAnimator.SetBool("fall", true);
    //myAnimator.SetBool("fall", false);

    //myAnimator.SetTrigger("jump");
    //myAnimator.ResetTrigger("jump");

    private void Update()
    {
        // What it means to be grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position,radOCircle,whaIsGround);

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            myAnimator.ResetTrigger("jump");
            myAnimator.SetBool("fall", false);
        }
    
        // Use space or w to jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            // Jump!
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            stoppedJumping = false;
            // Tell the animator to play jump anim
            myAnimator.SetTrigger("jump");
        }

        // To keep jumping while button is pressed
        if (Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0))
        {
            // Jump time!
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
            myAnimator.SetTrigger("jump");
        }

        // When release the jump button
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            myAnimator.SetBool("fall", true);
            myAnimator.ResetTrigger("jump");
        }

        if (rb.velocity.y < 0)
        {
            myAnimator.SetBool("fall", true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position,radOCircle);
    }

    private void FixedUpdate()
    {
        HandleLayers();
    }

    private void HandleLayers()
    {
        if (!grounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
}
