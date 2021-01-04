using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementInput;

    [SerializeField] private float speed = 15f;
    [SerializeField] private float jumpForce = 10f;

    private bool isGrounded;
    private Transform feetPos;
    private float checkRadius = 0.3f;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    private float jumpTime = 0.2f;
    private bool isJumping;

    private bool isFacingRight;

    private float wallSlideSpeed = 0.3f;
    private bool isWallSliding = false;
    private float wallDistance = 0.6f;
    RaycastHit2D WallCheckHit;

    private int numOfJumps = 1;

    public int chickensCarried;

    void Awake()
    {
        whatIsGround = LayerMask.GetMask("Ground");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetPos = GameObject.FindGameObjectWithTag("playerFeet").transform;
    }


    void Update()
    {
        Turn();
        Jump();
        speed = 15 - chickensCarried * 2;
    }

    void FixedUpdate()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movementInput * speed, rb.velocity.y);
    }

    private void Turn()
    {
        // Turning
        if (movementInput > 0)
        {
            isFacingRight = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (movementInput < 0)
        {
            isFacingRight = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void Jump()
    {
        // Jump
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            numOfJumps = 1;
        }

        if (numOfJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            numOfJumps--;
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }

        //Hold Jump
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        // wall slide
        if (isFacingRight)
        {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, whatIsGround);
        }
        else
        {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, whatIsGround);
        }

        if (WallCheckHit && !isGrounded && movementInput != 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlideSpeed, float.MaxValue));
        }
    }
}
