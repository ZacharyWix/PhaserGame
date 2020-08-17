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

    public SoundPlayer soundPlay;
    public Transform groundCheckPointLeft;
    public Transform groundCheckPointRight;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public SpriteRenderer accessory;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping = false;
    private bool previous;
    public ParticleSystem jumpParticles;
    public float coyoteTimeMax;
    private float coyoteTimer;
    public GameObject down, up, left, right, bdown, bup, bleft, bright;
    public GameObject space, a, d, bspace, ba, bd;

    public bool controlsEnabled = true; //Disables controls if set to false (for respawning)

    private bool isPractice;
    public GameObject practiceCheckpoint; //Object to spawn
    private GameObject checkpoint; //the spawned object

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isPractice = MainMenu.getPractice();
        
        if(isPractice)
        {
            checkpoint = Instantiate(practiceCheckpoint, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsEnabled)
        {
            isTouchingGround = checkGrounded();
            if(isTouchingGround)
            {
                coyoteTimer = coyoteTimeMax;
            } else
            {
                coyoteTimer -= Time.deltaTime;
            }
            if (!previous && isTouchingGround)
            {
                soundPlay.PlaySound("land");
                jumpParticles.Play();

            }
            movement = Input.GetAxis("Horizontal");
            if (movement > 0f)
            {
                rigidBody.velocity = new Vector2(movement * moveSpeed, rigidBody.velocity.y);
                spriteRenderer.flipX = false;
                accessory.flipX = false;
            }
            else if (movement < 0f)
            {
                rigidBody.velocity = new Vector2(movement * moveSpeed, rigidBody.velocity.y);
                spriteRenderer.flipX = true;
                accessory.flipX = true;
            }
            else
            {
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            }

            if (Input.GetButtonDown("Jump") && (isTouchingGround || coyoteTimer > 0f))
            {
                soundPlay.PlaySound("jump");
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

            if(isPractice && Input.GetButtonDown("Checkpoint") && isTouchingGround)
            {
                checkpoint.transform.position = gameObject.transform.position;
                checkpoint.transform.Translate(0, 0.13f, 0);
            }
            if (movement < 0f)
            {
                a.SetActive(false);
                ba.SetActive(true);
            }
            else
            {
                a.SetActive(true);
                ba.SetActive(false);
            }
            if (movement > 0f)
            {
                d.SetActive(false);
                bd.SetActive(true);
            }
            else
            {
                d.SetActive(true);
                bd.SetActive(false);
            }
            if (Input.GetButton("Jump"))
            {
                space.SetActive(false);
                bspace.SetActive(true);
            }
            else
            {
                space.SetActive(true);
                bspace.SetActive(false);
            }
            if (Input.GetButton("ColorGreen"))
            {
                down.SetActive(false);
                bdown.SetActive(true);
            }
            else
            {
                down.SetActive(true);
                bdown.SetActive(false);
            }
            if (Input.GetButton("ColorYellow"))
            {
                up.SetActive(false);
                bup.SetActive(true);
            }
            else
            {
                up.SetActive(true);
                bup.SetActive(false);
            }
            if (Input.GetButton("ColorBlue"))
            {
                left.SetActive(false);
                bleft.SetActive(true);
            }
            else
            {
                left.SetActive(true);
                bleft.SetActive(false);
            }
            if (Input.GetButton("ColorRed"))
            {
                right.SetActive(false);
                bright.SetActive(true);
            }
            else
            {
                right.SetActive(true);
                bright.SetActive(false);
            }
        }
        previous = isTouchingGround;
    }

    public void setControls(bool controls)
    {
        controlsEnabled = controls;
    }

    private bool checkGrounded()
    {
        bool leftCircle = Physics2D.OverlapCircle(groundCheckPointLeft.position, groundCheckRadius, groundLayer);
        bool rightCircle = Physics2D.OverlapCircle(groundCheckPointRight.position, groundCheckRadius, groundLayer);
        return (leftCircle || rightCircle);
    }
}
