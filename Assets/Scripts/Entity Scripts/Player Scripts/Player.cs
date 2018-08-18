using UnityEngine;

public enum MovementState { Idle, Moving };


public class Player : Character {

    #region MemberVariables
    MovementComponent m_MovementComponent;
    RangedWeapon m_RangedWeapon;
    JumpComponent m_JumpComponent;
    GroundCheck m_GroundCheck;
    WallCheck m_WallCheck;
    DeathComponent m_DeathComponent;
    Rigidbody2D m_Rigidbody2D;
    Health m_Health;

    #endregion

    #region Fields

    public override Health Health
    {
        get
        {
            return m_Health;
        }
    }
    public override JumpComponent JumpComponent
    {
        get
        {
            return m_JumpComponent;
        }

    }

    public override DeathComponent DeathComponent
    {
        get
        {
            return m_DeathComponent;
        }

    }
    public override WallCheck WallCheck
    {
        get
        {
            return m_WallCheck;
        }

    }

    public override GroundCheck GroundCheck
    {
        get
        {
            return m_GroundCheck;
        }

    }

    public override Rigidbody2D Rigidbody2D
    {
        get
        {
            return m_Rigidbody2D;
        }

    }

    public override MovementComponent MovementComponent
    {
        get
        {
            return m_MovementComponent;
        }

    }
    #endregion

    public float attackSpeed = 0.2f;
    public float attackCooldown = 0f;

    /* States */
    public bool climbing = false;
    public MovementState movementState = MovementState.Idle;
    public bool isJumping = false, isCrouching = false, isAttacking = false, isAiming = false;




    // Use this for initialization
    void Start () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Health = GetComponent<Health>();
        
        
        transform.position = LevelManager.instance.GetSpawnPoint().transform.position;
        m_MovementComponent = GetComponent<MovementComponent>();
        m_RangedWeapon = GetComponentInChildren<RangedWeapon>();
        m_JumpComponent = GetComponent<JumpComponent>();
        m_GroundCheck = GetComponent<GroundCheck>();
        m_WallCheck = GetComponent<WallCheck>();

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
        if (m_Rigidbody2D.velocity.magnitude > 0)
        {
            movementState = MovementState.Moving; 
        } else
        {
            movementState = MovementState.Idle;

        }

        if(climbing && m_GroundCheck.groundState == GroundState.Grounded)
        {
            StopClimbing();
        }
        //If the player is falling
        if(isJumping && (m_Rigidbody2D.velocity.y <= 0 || m_WallCheck.IsWall))
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
            if (m_GroundCheck.groundState == GroundState.Grounded && !isAttacking)
            {
                isCrouching = true;
                m_Rigidbody2D.velocity = new Vector2(0, 0);
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
                m_Rigidbody2D.velocity = new Vector2(0, -1.25f);
            }
            else
            {

                MovementComponent.MoveHorizontal();    
            }
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            //Initial Jump
            if (m_GroundCheck.groundState == GroundState.Grounded)
            {
                m_JumpComponent.Jump();
                isJumping = true;
            }
            else
            {
                if (m_WallCheck.IsWall)
                {
                    MovementComponent.Direction = (Direction)(-(int)MovementComponent.Direction);
                    m_JumpComponent.JumpAway(MovementComponent.Direction);
                    isJumping = true;
                }

                if (climbing)
                {
                    //the initial jumping force
                    StopClimbing();

                    m_JumpComponent.JumpAway(MovementComponent.Direction);
                    isJumping = true;
                }
            }
            
           
        } else if (Input.GetButton("Jump") && isJumping) {

            //if we continue to hold the jump button, add a bit more force
                m_JumpComponent.AddToJump(); 
            
        } else
        {
            if (m_JumpComponent.jumping)
            {
                m_JumpComponent.jumping = false;
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
                m_RangedWeapon.UpdateAngle(input);

                if (Input.GetButtonDown("Fire"))
                {
                    m_RangedWeapon.Shoot();
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
            
            if(Input.GetAxis("LVertical") > 0 || Input.GetAxis("LVertical") < 0)
            {
                if (!climbing)
                {
                    StartClimbing(collision.transform);
                }
                m_MovementComponent.MoveVertical(5 * Input.GetAxis("LVertical"));
            } else if(climbing)
            {
                m_Rigidbody2D.velocity = new Vector2(0, 0);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ladder" && climbing)
        {
            StopClimbing();

        }
    }

    void StartClimbing(Transform t)
    {

        m_Rigidbody2D.gravityScale = 0;
        climbing = true;
        transform.position = new Vector2(t.position.x, transform.position.y);
        m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

    }


    void StopClimbing()
    {

        climbing = false;
        m_Rigidbody2D.gravityScale = 2;
        m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }
}
