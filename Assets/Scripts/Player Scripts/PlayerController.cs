using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroundState { Grounded, Airborn };
public enum PlayerState { Idle, Walk, Jump, Falling, Crouch };

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;
    AnimationController renderer;
    public float walkSpeed = 4;
    public float jumpSpeed = 150;
    public float maxJumpHeight = 350;
    public float minJumpHeight = 200;
    public GroundState groundState = GroundState.Grounded;
    public PlayerState playerState = PlayerState.Idle;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<AnimationController>();
    }
    void StateHandler()
    {
        if (rb.velocity.y == 0 && rb.velocity.x == 0 && playerState != PlayerState.Crouch)
        {
            playerState = PlayerState.Idle;
         }
        else
        {
            if (rb.velocity.y > 0)
            {
                playerState = PlayerState.Jump;

            }
            else if (rb.velocity.y < 0)
            {
                playerState = PlayerState.Falling;

            }

            if (groundState == GroundState.Grounded && rb.velocity.x != 0)
            {
                playerState = PlayerState.Walk;

            }
        }

    }
    // SetFlag("IsWalking", true);

  

    // Update is called once per frame
    void Update () {

        //Movement
        StateHandler();
    }

 
}
