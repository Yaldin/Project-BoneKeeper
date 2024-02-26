using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public abstract class Character : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] protected float speed = 1.0f;
    [SerializeField] protected float direction;

    protected bool facingRight = true;


    //[Header("Jump Variables")]

    //[Header("Attack Variables")]

    //[Header("Character Stats")]

    protected Rigidbody2D rb;
    protected Animator myAnimator;

    #region monos
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    public virtual void Update()
    {
        // Handle input
        // HandleJumping();

    }
    public virtual void FixedUpdate()
    {
        // Handle Mechanics/physics
        HandleMovement();
    }
    #endregion

    #region mechanics

    protected void Move()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    #endregion

    #region subMechanics
    protected virtual void HandleMovement()
    {
        Move();
    }
    protected void TurnAround(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        #endregion

    }
}
