using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    Rigidbody2D rb;
    public float walkSpeed = 5;
    public float jumpSpeed = 5;
    public bool isWalking;
    public bool isCrouch;
    public bool isGrounded;
    public bool isJumping;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame

	void Update () {
        moveMent();
		
	}


    //HANDLES THE PLAYERS MOVEMENT
    //*****************************************
    //***************************************
    void moveMent(){
        
        var x = getXInput();
        var y = getYInput();
        print("X: " + x + "Y: " + y);
        rb.AddForce(new Vector2(x, y));
    }

    float getXInput() {
        float x = Input.GetAxis("Horizontal") * walkSpeed;

        //Is the player walking.
        if (x > 0 || x < 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        return x;
    }

    float getYInput(){

        float y;
        //IF grounded state check
        y = Input.GetAxis("Vertical") * jumpSpeed;
        
        if(y < 0)
        {
            GetComponent<Animator>().SetBool("isCrouching", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isCrouching", false);
        }

        GetComponent<Animator>().SetBool("isJumping", false);

        if (y > 0)
        {
            GetComponent<Animator>().SetBool("isJumping", true);
            return y;
        }

        
        return 0;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            GetComponent<Animator>().SetBool("isGrounded", true);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            GetComponent<Animator>().SetBool("isGrounded", false);
        }
    }
    //END OF PLAYERS MOVEMENT FEATURES
    // **************************************
    //*****************************************
}
