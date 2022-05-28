using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpSpeed = 14f;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //get's horizontal input
        float dir = Input.GetAxisRaw("Horizontal");

        //determines if the player is moving
        if (rb.velocity.x + dir * moveSpeed != rb.velocity.x) animator.SetBool("isMoving", true);
        else animator.SetBool("isMoving", false);

        //if the player moves, it sets the parameter to the animator
        if (dir != 0) animator.SetFloat("XInput", dir);

        //creates the movement
        rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);

        //Jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(0, jumpSpeed, 0);
        }

        //checks if the player is not touching the ground
        if (!IsGrounded())
        {
            animator.SetBool("isJumping", true);
        }
        else if(IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }

        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isMouseDown");
        }

    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
