using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

    private float movementInputDirection;
    private float jumpTimer;
    private float turnTimer;
    /*
    private float dashTimeLeft;
    private float lastImageXpos;
    private float lastDash = -100;
    */

    private int amountOfJumpsLeft;

    private bool isFacingRight = true;
    private bool isWalking;
    private bool isGrounded;
    private bool isTouchWall;
    private bool canNormalJump;
    private bool canWallJump;
    private bool isWallSliding;
    private bool isAttemptingJump;
    private bool checkJumpMultiplier;
    private bool canMove;
    private bool canFlip;

    private bool isDashing;

    private bool enableDash;
    private bool enableWallJump;
    private bool enableWallSlide;

    private Rigidbody2D rb;
    private Animator anim;
    private Damageable dmg;


    private int amountOfJumps = 1;
    private int facingDirection = 1;

    public float movementSpeed = 10.0f;
    private float jumpForce = 16.0f;

    private float wallSlideSpeed = 1;
    private float groundCheckRadius = 0.25f;
    private float wallCheckDistance = 0.4f;
    
    private float airDragMultiplier = 0.95f;
    private float variableJumpHeightMultiplier = 0.5f;
    private float turnTimerSet = 0.1f;

    private float wallJumpForce = 25;
    private float jumpTimerSet = 0.15f;
    /*
    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCooldown;
    */

    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;

    public Transform groundCheck;
    public Transform wallCheck;

    public LayerMask WhatIsGround;

    public bool isEnter = true;

    // Start is called before the first frame update
    void Awake()
    { 
        dmg = GetComponent<Damageable>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        amountOfJumpsLeft = amountOfJumps;
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDir();
        UpdateAnimations();
        CheckIfCanJump();
        checkIfWallSliding();
        checkJump();
        checkIfDead();
        //checkDash();
    }

      void checkIfDead()
    {
        if(!dmg.IsAlive)
        {
            canFlip = false;
            canMove = false;
            canNormalJump = false;
            canWallJump = false;
            anim.SetBool("isAlive", false);
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

    public void SetAbilities(bool ableToWallJump, bool ableToDash, bool ableToWallSlide)
    {
        enableDash = ableToDash;
        enableWallJump = ableToWallJump;
        enableWallSlide = ableToWallSlide;
    }

    public void SetStats(int jumps, float speed, float jumpforce)
    {
        amountOfJumps = jumps;
        movementSpeed = speed;
        jumpForce = jumpforce;
        /* 
        dashSpeed = dSpeed;
        dashCooldown = dCooldown;
        dashTime = dDuration;
        */
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, WhatIsGround);
        isTouchWall = Physics2D.Raycast(wallCheck.position,transform.right,wallCheckDistance,WhatIsGround);
    }

    private void CheckIfCanJump()
    {
        if(isGrounded && rb.velocity.y <= 0.01f)
        {
            amountOfJumpsLeft = amountOfJumps;
        }
        if (enableWallJump)
        {
            if (isTouchWall)
            {
                canWallJump = true;
            }
            else
            {
                canWallJump = false;
            }
        }

        if (amountOfJumpsLeft <= 0)
        {
            canNormalJump = false;
        }
        else
        {
            canNormalJump = true;
        }
        
    }


    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isWallSliding", isWallSliding);
    }

    private void CheckInput() {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded || amountOfJumpsLeft > 0 && !isTouchWall)
            {
                normalJump();
            }
            else
            {
                jumpTimer = jumpTimerSet;
                isAttemptingJump = true;
            }
        }

        if(Input.GetButtonDown("Horizontal") && isTouchWall)
        {
            if(!isGrounded && movementInputDirection != facingDirection)
            {
                canMove = false;
                canFlip = false;

                turnTimer = turnTimerSet;
            }
        }

        if (!canMove)
        {
                turnTimer -= Time.deltaTime;
            if (turnTimer <= 0)
            {
                canMove = true;
                canFlip = true;
            }
        }

        //code for variable jump height
        if (checkJumpMultiplier && !Input.GetButton("Jump"))
        {
            checkJumpMultiplier = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeightMultiplier);
        }
        
        /*
        if (Input.GetButtonDown("Dash") && enableDash && movementInputDirection !=0)
        { 
            AttemptToDash();
        }
        */
    }

    private void CheckMovementDir()
    {
        if (isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }else if(!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        if(rb.velocity.x >= 0.1 || rb.velocity.x <= -0.1) // 
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void checkIfWallSliding()
    {
        if (enableWallSlide)
        {
            if (isTouchWall && movementInputDirection == facingDirection && rb.velocity.y < 0)
            {
                isWallSliding = true;
            }
            else
            {
                isWallSliding = false;
            }
        }
    }

    /*
    private void checkDash()
    {
        if (enableDash && isDashing)
        { 
                canMove = false;
                canFlip = false;

                rb.velocity = new Vector2(dashSpeed * facingDirection, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;
            if (dashTimeLeft > 0)
            {
                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages) 
                {
                    PlayerAfterImagePool.instance.getFromPool();
                    lastImageXpos = transform.position.x;
                }
            }
            if (dashTimeLeft <= 0 || isTouchWall)
            {
                isDashing = false;
                canMove = true;
                canFlip = true;
            }
        }
    }

    private void AttemptToDash()
    {
        if (enableDash)
        {
            isDashing = true;
            dashTimeLeft = dashTime;
            lastDash = Time.time;
            PlayerAfterImagePool.instance.getFromPool();
            lastImageXpos = transform.position.x;
        }
    }*/

    private void checkJump()
    {
        if (jumpTimer > 0)
        {
            // walljump
            if(!isGrounded && isTouchWall && movementInputDirection != 0 && movementInputDirection != facingDirection)
            {
                wallJump();
            }
            else if (isGrounded)
            {
                normalJump();
            }
            
            if(isAttemptingJump)
            {
                jumpTimer -= Time.deltaTime;
            }
        }
    }

    private void normalJump()
    {
        if (canNormalJump && !isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;
            jumpTimer = 0;
            isAttemptingJump = false;
            checkJumpMultiplier = true;
        }
    }

    private void wallJump()
    {
        if (canWallJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0) ;
            isWallSliding = false;
            amountOfJumpsLeft = amountOfJumps;
            amountOfJumpsLeft--;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * movementInputDirection, wallJumpForce * wallJumpDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            jumpTimer = 0;
            isAttemptingJump = false;
            checkJumpMultiplier = true;
            turnTimer = 0;
            canMove = true;
            canFlip = true;
        }
    }

    private void ApplyMovement()
    {
        if (canMove && !dmg.getIsKnocked())
        {
            if (!isGrounded && !isWallSliding && movementInputDirection == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
            }
        }
        if (isWallSliding)
        {
            if(rb.velocity.y < -wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }
    }

    private void Flip()
    {
        if (!isWallSliding && !isDashing && canFlip)
        {
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    public void FindSpawn()
    {
        GameObject spawnPoint;
        if (isEnter)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("Entrance");
        }
        else
        {
            spawnPoint = GameObject.FindGameObjectWithTag("Exit");
        }

        if (spawnPoint != null)
        {
            spawnPoint.GetComponent<PlayerTransition>().pull = true;
        }
    }

private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }
}
