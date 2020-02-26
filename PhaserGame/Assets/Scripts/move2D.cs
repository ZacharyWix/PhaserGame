using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    private float movement = 0f;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping = false;

    public bool controlsEnabled = true; //Disables controls if set to false (for respawning)

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsEnabled)
        {
            isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
            movement = Input.GetAxis("Horizontal");
            if (movement > 0f)
            {
                rigidBody.velocity = new Vector2(movement * moveSpeed, rigidBody.velocity.y);
                spriteRenderer.flipX = false;
            }
            else if (movement < 0f)
            {
                rigidBody.velocity = new Vector2(movement * moveSpeed, rigidBody.velocity.y);
                spriteRenderer.flipX = true;
            }
            else
            {
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            }

            if (Input.GetButtonDown("Jump") && isTouchingGround)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            }

            if (Input.GetButton("Jump") && isJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
        }
    }

    public void setControls(bool controls)
    {
        controlsEnabled = controls;
    }
}
