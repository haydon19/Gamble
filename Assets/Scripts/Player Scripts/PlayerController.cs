﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroundState { Grounded, Airborn };
public enum PlayerState { Idle, Walk, Jump, Falling, Crouch, Attacking, RangedAttack };
public enum Direction { Left = -1, Right = 1 };


public class PlayerController : MonoBehaviour {
    public Rigidbody2D rb;


    public Direction direction = Direction.Right;
    public float health = 20;
    public float maxHealth = 30;
    public float walkSpeed = 4;
    public float jumpSpeed = 150;
    public GroundState groundState = GroundState.Grounded;
    public PlayerState playerState = PlayerState.Idle;
    public PlayerState previousState;
    public float attackSpeed = 0.04f;
    public float attackCooldown = 0f;
    public bool wallSliding = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        previousState = PlayerState.Idle;
        HealthBar.instance.UpdateHealth(health, maxHealth);
        transform.position = LevelManager.instance.GetSpawnPoint().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                attackCooldown = 0;
            }
        }
        StateHandler();
        //Sets the players state based on its movement
        HandleInput();
    }


    void StateHandler()
    {
        if (playerState == PlayerState.Attacking || playerState == PlayerState.RangedAttack)
            return;

        //By default the player is always idle or falling (unless they are attacking)
        //When we handle the input afterwards, the proper state will be set
        if(groundState == GroundState.Grounded)
        {
            playerState = PlayerState.Idle;
        } else
        {
            if(rb.velocity.y <= 0)
            playerState = PlayerState.Falling;
            else
            playerState = PlayerState.Jump;

        }

    }

    void HandleInput()
    {

        //This all comes down to the order of operations
        //Getting that order correct will be key

        /*Crouch*/
        if (Input.GetAxis("LVertical") < -0.5 && groundState == GroundState.Grounded && playerState != PlayerState.Attacking)
        {
            playerState = PlayerState.Crouch;
            rb.velocity = new Vector2(0, 0);
        }

        /*WALKING*/
        if (Input.GetAxis("LHorizontal") != 0 && playerState != PlayerState.Attacking)
        {

            //Unity's inspector has a better way to do this. But I like to see it for now.
            if (Input.GetAxis("LHorizontal") < 0)
            {
                direction = Direction.Left;


            }

            if (Input.GetAxis("LHorizontal") > 0)
            {
                direction = Direction.Right;

            }

            if (wallSliding)
            {
                rb.velocity = new Vector2(0, -1.25f);
                playerState = PlayerState.Falling;
            }
            else
            {
                rb.velocity = new Vector2(walkSpeed * (int)direction, rb.velocity.y);
                
                if(groundState == GroundState.Grounded)
                playerState = PlayerState.Walk;
            }
        }

        /*JUMPING*/
        if (Input.GetButton("Jump"))
        {
            if (groundState == GroundState.Grounded && playerState != PlayerState.Jump)
            {
                Debug.Log("being called");
                //the initial jumping force
                Vector2 jumpingPower = new Vector2(0, jumpSpeed);
                rb.AddForce(jumpingPower, ForceMode2D.Impulse);
                playerState = PlayerState.Jump;
                //player.groundState = GroundState.Airborn;
            }
            else if (playerState == PlayerState.Jump)
            {
                //if we continue to hold the jump button, add a bit more force
                rb.AddForce(new Vector2(0, 10f));
                //rb.
                playerState = PlayerState.Jump;
            }
        }
        

        /*Ranged Attacking*/
        if (Input.GetAxis("RHorizontal") != 0 || Input.GetAxis("RVertical") != 0 && playerState != PlayerState.Attacking)
        {
            playerState = PlayerState.RangedAttack;
            //print("PlayerState: RangedAttack");
            if (Input.GetButtonDown("Fire"))
            {
                print("Shot Fired!");
            }

        }

        /*Attacking*/
        if (Input.GetButtonDown("Attack") && attackCooldown <= 0 && playerState != PlayerState.RangedAttack)
        {
            attackCooldown = attackSpeed;
            previousState = playerState;
            //print("Attack Pressed!");
            playerState = PlayerState.Attacking;
        }
        //print("Y Velocity " + rb.velocity.y);

    }
  




    public void SetToPreviousState()
    {
        playerState = previousState;
    }

    public void SetPlayerState(PlayerState state)
    {
        playerState = state;
    }
 
}
