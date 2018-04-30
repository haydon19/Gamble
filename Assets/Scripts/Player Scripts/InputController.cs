using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        print("X: " + Input.GetAxis("Horizontal") + " Y: " + Input.GetAxis("Vertical"));

        jump();
        walk();
        
        if (Input.GetAxis("Vertical") < 0 && player.groundState == GroundState.Grounded)
        {
            player.playerState = PlayerState.Crouch;
        }


    }


    public void jump()
    {
        print("A Button Pressed");
        if (Input.GetKey("joystick button 0") && player.groundState == GroundState.Grounded)
        {
            Vector2 jumpingPower = new Vector2(0, player.jumpSpeed);
            rb.AddForce(jumpingPower);
        }
    }

    public void walk()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            //Unity's inspector has a better way to do this. But I like to see it for now.
            if (Input.GetAxis("Horizontal") > 0)
            {
                rb.AddForce(new Vector2(player.walkSpeed, 0));
            }
            else
            {
                rb.AddForce(new Vector2(player.walkSpeed * -1, 0));
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            print("Player State: Grounded");
           player.groundState = GroundState.Grounded;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            print("Player State: Airborne");
            player.groundState = GroundState.Airborn;
        }
    }



}
