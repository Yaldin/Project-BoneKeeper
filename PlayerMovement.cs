using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    // This are a necessary for animations and physics
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    private bool facingRight = true;

    // Variables to play whith
    public float speed = 2.0f;
    public float horizMovement;  // = 1 [or] -1 [or] 0

    private void Start()
    {
        // Define the game objects found on the player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Handles the input for physics
    private void Update()
    {
        // Check if the player has input movement
        horizMovement = Input.GetAxis("Horizontal");
    }
    // Handles running the physics
    private void FixedUpdate()
    {
        // Move the char left or right
        rb2D.velocity = new Vector2(horizMovement * speed, rb2D.velocity.y);
        Flip(horizMovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
    }

    // Flipping function
    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
