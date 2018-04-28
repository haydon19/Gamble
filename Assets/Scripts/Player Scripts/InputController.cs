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

        if (Input.GetAxis("Vertical") < 0 && player.groundState == GroundState.Grounded)
        {
            player.playerState = PlayerState.Crouch;
        }
        else
        {
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * player.walkSpeed, Input.GetAxis("Vertical") * player.jumpSpeed));
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
           player.groundState = GroundState.Grounded;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            player.groundState = GroundState.Airborn;
        }
    }



}
