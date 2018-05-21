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
    List<BoxCollider2D> colliders;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
        colliders = new List<BoxCollider2D>();
        colliders.AddRange(GetComponentsInChildren<BoxCollider2D>());
    }

    // Update is called once per frame

    void Update()
    {
        /*
        if(Input.GetAxis("Vertical") < 0 && Input.GetButtonDown("Jump"))
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
            Vector2 jumpingPower = new Vector2(0, player.jumpSpeed);
            rb.AddForce(jumpingPower, ForceMode2D.Impulse);
        }
    }

    public void walk()
    {
        if (Input.GetAxis("LHorizontal") != 0)
        {
            //Unity's inspector has a better way to do this. But I like to see it for now.
            if (Input.GetAxis("LHorizontal") > 0)
            {
                rb.AddForce(new Vector2(player.walkSpeed, 0));
            }
            else
            {
                rb.AddForce(new Vector2(player.walkSpeed * -1, 0));
            }
        }
    }





}
