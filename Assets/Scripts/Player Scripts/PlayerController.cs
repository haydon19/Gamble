using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroundState { Grounded, Airborn };
public enum PlayerState { Idle, Walk, Jump, Falling, Crouch, Attacking, RangedAttack};

public class PlayerController : MonoBehaviour {
    public Rigidbody2D rb;
    AnimationController renderer;

    public float health = 20;
    public float maxHealth = 30;
    public float walkSpeed = 4;
    public float jumpSpeed = 150;
    public float maxJumpHeight = 350;
    public float minJumpHeight = 200;
    public GroundState groundState = GroundState.Grounded;
    public PlayerState playerState = PlayerState.Idle;
    public PlayerState previousState;
    public float attackSpeed = 0.04f;
    public float attackCooldown = 0f;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<AnimationController>();
        previousState = PlayerState.Idle;
        HealthBar.instance.UpdateHealth(health, maxHealth);
    }
    void StateHandler()
    {
        if(attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            if(attackCooldown <= 0)
            {
                attackCooldown = 0;
            }
        }

        if (playerState == PlayerState.Attacking)
        {
            return;
        }

        //Added Wednesday 2018-05-09
        if(playerState == PlayerState.RangedAttack)
        {
            return;
        }

        if (rb.velocity.y == 0 && rb.velocity.x == 0 && playerState != PlayerState.Crouch && groundState == GroundState.Grounded)
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

  

    // Update is called once per frame
    void Update () {

        //Sets the players state based on its movement
        StateHandler();
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
