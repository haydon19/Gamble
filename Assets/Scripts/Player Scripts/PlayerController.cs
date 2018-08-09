using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementState { Idle, Moving };

public enum Direction { Left = -1, Right = 1 };


public class PlayerController : MonoBehaviour {
    MovementComponent movementComponent;
    RangedWeapon rangedWeapon;
    JumpComponent jumpComponent;
    GroundCheck groundCheck;
    public Rigidbody2D rb;


    public float health = 20;
    public float maxHealth = 30;
    public float walkSpeed = 4;
    public float jumpSpeed = 8;
    public float attackSpeed = 0.2f;
    public float attackCooldown = 0f;
    public bool climbing = false;
    /* States */
    public MovementState movementState = MovementState.Idle;
    public bool isJumping = false, isCrouching = false, isAttacking = false, isAiming = false;

    public GroundCheck GroundCheck
    {
        get
        {
            return groundCheck;
        }

        set
        {
            groundCheck = value;
        }
    }

    public WallCheck WallCheck
    {
        get
        {
            return wallCheck;
        }

        set
        {
            wallCheck = value;
        }
    }

    public MovementComponent MovementComponent
    {
        get
        {
            return movementComponent;
        }

        set
        {
            movementComponent = value;
        }
    }

    private WallCheck wallCheck;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        HealthBar.instance.UpdateHealth(health, maxHealth);
        transform.position = LevelManager.instance.GetSpawnPoint().transform.position;
        MovementComponent = gameObject.AddComponent<MovementComponent>();
        rangedWeapon = GetComponentInChildren<RangedWeapon>();
        jumpComponent = GetComponent<JumpComponent>();
        GroundCheck = GetComponent<GroundCheck>();
        WallCheck = GetComponent<WallCheck>();

    }

    private void FixedUpdate()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                attackCooldown = 0;
                isAttacking = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        StateHandler();
        //Sets the players state based on its movement
        HandleInput();
    }


    void StateHandler()
    {

        if (climbing)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        } else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        //Check whether the player is moving or not, and set our movestate
        if (rb.velocity.magnitude > 0)
        {
            movementState = MovementState.Moving; 
        } else
        {
            movementState = MovementState.Idle;

        }

        //If the player is falling
        if(isJumping && (rb.velocity.y <= 0 || wallCheck.IsWall))
        {
            isJumping = false;
        }

    }

    void HandleInput()
    {
        float leftInputX = Input.GetAxis("LHorizontal");
        float leftInputY = Input.GetAxis("LVertical");
        float rightInputX = Input.GetAxis("RHorizontal");
        float rightInputY = Input.GetAxis("RVertical");
        //This all comes down to the order of operations
        //Getting that order correct will be key

        /*Crouch*/

        if (leftInputY < -0.5 && !climbing)
        {
            if (GroundCheck.groundState == GroundState.Grounded && !isAttacking)
            {
                isCrouching = true;
                rb.velocity = new Vector2(0, 0);
            }
        }
        else if(isCrouching)
        {
            isCrouching = false;
        }


        /*WALKING*/
        if (leftInputX != 0)
        {

            //Consider moving the direction variable into movement component
            if (leftInputX < 0)
            {
                MovementComponent.Direction = Direction.Left;
            }

            if (leftInputX > 0)
            {
                MovementComponent.Direction = Direction.Right;
            }

            if (WallCheck.IsWall)
            {
                //Moving into the wall sticks
                rb.velocity = new Vector2(0, -1.25f);
            }
            else
            {

                MovementComponent.MoveHorizontal((int)MovementComponent.Direction * walkSpeed);    
            }
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            if (WallCheck.IsWall && GroundCheck.groundState != GroundState.Grounded)
            {
                MovementComponent.Direction = (Direction)(-(int)MovementComponent.Direction);
                jumpComponent.JumpAway(MovementComponent.Direction);
                isJumping = true;
            }
            //Initial Jump
            if (GroundCheck.groundState == GroundState.Grounded && !isJumping)
            {
                //the initial jumping force
                jumpComponent.Jump();
                isJumping = true;

            }
        } else if (Input.GetButton("Jump") && isJumping) {

            //if we continue to hold the jump button, add a bit more force
                jumpComponent.AddToJump(); 
            
        } else
        {
            if (jumpComponent.jumping)
            {
                jumpComponent.jumping = false;
            }
        }
        

        /*Ranged Attacking*/
        if (rightInputX != 0 || rightInputY != 0)
        {
            if (!isAttacking)
            {
                if (isCrouching)
                    isCrouching = false;

                isAiming = true;
                Vector2 input = new Vector2(rightInputX, rightInputY);
                rangedWeapon.UpdateAngle(input);

                if (Input.GetButtonDown("Fire"))
                {
                    rangedWeapon.Shoot();
                }
            }
        }
        else
        {
            isAiming = false;
        }

        /*Attacking*/
        if (!isAttacking && Input.GetButtonDown("Attack"))
        {
            if (isAiming)
                isAiming = false;
            if (isCrouching)
                isCrouching = false;

            attackCooldown = attackSpeed;
            isAttacking = true;
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            if(Input.GetAxis("LVertical") == 1)
            {
                climbing = true;
                transform.position = new Vector2( collision.transform.position.x, transform.position.y);
                movementComponent.MoveVertical(collision.GetComponent<Ladder>().ClimbSpeed);
            } else if (Input.GetAxis("LVertical") == -1)
            {
                climbing = true;
                transform.position = new Vector2(collision.transform.position.x, transform.position.y);
                movementComponent.MoveVertical(-collision.GetComponent<Ladder>().ClimbSpeed);
            } else if(climbing)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(0, 0);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ladder" && climbing)
        {
            climbing = false;
            rb.gravityScale = 2;

        }
    }


}
