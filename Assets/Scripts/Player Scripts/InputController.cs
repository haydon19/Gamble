using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * MODIFIED: Wednesday, 2018-05-09 : Changed "Horizontal" -> "LHorizontal" and "Vertical" -> "LVertical" for use of left stick and right stick.
 * 
 */


public class InputController : MonoBehaviour {


    Rigidbody2D rb;
    PlayerController player;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame

    void Update()
    {
         
        /*
        if(Input.GetAxis("LVertical") < 0 && Input.GetButtonDown("Jump"))
        {
            foreach(BoxCollider2D collider in colliders)
            {
                collider.isTrigger = true;
            }

        }
        */
        //print("X: " + Input.GetAxis("Horizontal") + " Y: " + Input.GetAxis("Vertical"));

        jump();
        walk();
        

        if (Input.GetAxis("LVertical") < 0 && player.groundState == GroundState.Grounded && player.playerState == PlayerState.Idle)
        {
            player.playerState = PlayerState.Crouch;
        }

        

        if(Input.GetAxis("LVertical") >= 0 && Input.GetAxis("LHorizontal") == 0 && player.groundState == GroundState.Grounded && player.playerState != PlayerState.Attacking)
        {
            //print("Setting Idle");
            player.playerState = PlayerState.Idle;
        }

        if (Input.GetButtonDown("Attack") && player.playerState != PlayerState.Attacking && player.attackCooldown == 0)
        {
            player.attackCooldown = player.attackSpeed;
            player.previousState = player.playerState;
            //print("Attack Pressed!");
            player.playerState = PlayerState.Attacking;
        }
        /*Added Wednesday 2018-05-09
    
         
         */
        if(Input.GetAxis("RHorizontal") != 0 || Input.GetAxis("RVertical") != 0 && player.playerState != PlayerState.Attacking && player.attackCooldown == 0)
        {
            player.playerState = PlayerState.RangedAttack;
            //print("PlayerState: RangedAttack");
            if (Input.GetButtonDown("Fire"))
            {
                print("Shot Fired!");
            }
            
        }


    }


    public void jump()
    {

        if (Input.GetButtonDown("Jump") && player.groundState == GroundState.Grounded && Input.GetAxis("LVertical") >= 0)
        {
            //the initial jumping force
            Vector2 jumpingPower = new Vector2(0, player.jumpSpeed);
            rb.AddForce(jumpingPower, ForceMode2D.Impulse);
            //player.groundState = GroundState.Airborn;
        } else if(Input.GetButton("Jump") && player.playerState == PlayerState.Jump) 
        {
            //if we continue to hold the jump button, add a bit more force
            rb.AddForce(new Vector2(0, 10f));

        }
       
    }

    public void walk()
    {
        if (Input.GetAxis("LHorizontal") != 0)
        {


            //Unity's inspector has a better way to do this. But I like to see it for now.
            if (Input.GetAxis("LHorizontal") < 0)
            {
                player.direction = Direction.Left;

            }

            if (Input.GetAxis("LHorizontal") > 0)
            {
                player.direction = Direction.Right;

            }

            if (player.wallSliding)
            {
                rb.velocity = new Vector2(0, -1.25f);

            }
            else
            {
                rb.velocity = new Vector2(player.walkSpeed * (int)player.direction, rb.velocity.y);

            }
            //print("Y Velocity " + rb.velocity.y);
        }
    }





}
