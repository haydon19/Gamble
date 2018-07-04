using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroundState { Grounded, Airborn };
public enum MovementState { Idle, Moving };

public enum Direction { Left = -1, Right = 1 };


public class PlayerController : MonoBehaviour {
    MovementComponent movementComponent;
    RangedWeapon rangedWeapon;
    JumpComponent jumpComponent;
    public Rigidbody2D rb;


    public Direction direction = Direction.Right;
    public float health = 20;
    public float maxHealth = 30;
    public float walkSpeed = 4;
    public float jumpSpeed = 8;
    public GroundState groundState = GroundState.Grounded;
    public float attackSpeed = 0.2f;
    public float attackCooldown = 0f;

    /* States */
    public MovementState movementState = MovementState.Idle;
    public bool isJumping = false, isCrouching = false, isAttacking = false, isAiming = false, isWallSlide = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        HealthBar.instance.UpdateHealth(health, maxHealth);
        transform.position = LevelManager.instance.GetSpawnPoint().transform.position;
        movementComponent = gameObject.AddComponent<MovementComponent>();
        rangedWeapon = GetComponentInChildren<RangedWeapon>();
        jumpComponent = GetComponent<JumpComponent>();
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
        //Check whether the player is moving or not, and set our movestate
        if(rb.velocity.magnitude > 0)
        {
            movementState = MovementState.Moving; 
        } else
        {
            movementState = MovementState.Idle;

        }

        //If the player is falling
        if(isJumping && rb.velocity.y <= 0)
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

        if (leftInputY < -0.5)
        {
            if (groundState == GroundState.Grounded && !isAttacking)
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
                direction = Direction.Left;
            }

            if (leftInputX > 0)
            {
                direction = Direction.Right;
            }

            if (isWallSlide)
            {
                //Moving into the wall sticks
                rb.velocity = new Vector2(0, -1.25f);
            }
            else
            {
                movementComponent.MoveHorizontal((int)direction * walkSpeed);    
            }
        }

        /*JUMPING*/
        if (Input.GetButton("Jump"))
        {
            //Initial Jump
            if (groundState == GroundState.Grounded && !isJumping)
            {
                //the initial jumping force
                jumpComponent.Jump();
                isJumping = true;
                
            }
            else if (isJumping)
            {
                //if we continue to hold the jump button, add a bit more force
                jumpComponent.AddToJump();
            }
            
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
  



 
}
