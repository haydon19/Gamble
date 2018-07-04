using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAnimationState { Idle, Walk, Jump, Falling, Crouch, Attacking, RangedAttack };


[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour {

    PlayerController player;
    Animator animator;
    SpriteRenderer spriteRenderer;
    //Need access to PlayerController Functions to know what the player is doing.
    public GameObject armRotation;

    // Use this for initialization
    void Start() {
        player = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void SetAnimationState()
    {
        if (player.isAttacking)
        {
            animator.SetInteger("PlayerState", (int)PlayerAnimationState.Attacking);
            return;
        }

        if (player.isJumping)
        {
            animator.SetInteger("PlayerState", (int)PlayerAnimationState.Jump);
            return;
        }

        
        if(player.groundState == GroundState.Airborn)
        {
            if (!player.isJumping)
            {
                animator.SetInteger("PlayerState", (int)PlayerAnimationState.Falling);
                return;
            }
        }
        else
        {
            if(player.movementState == MovementState.Moving)
            {
                animator.SetInteger("PlayerState", (int)PlayerAnimationState.Walk);
                return;
            }
            else
            {
                if (player.isCrouching)
                {
                    animator.SetInteger("PlayerState", (int)PlayerAnimationState.Crouch);
                    return;
                }
                if (player.isAiming)
                {
                    animator.SetInteger("PlayerState", (int)PlayerAnimationState.RangedAttack);
                    return;
                }
                
            }
        }


        animator.SetInteger("PlayerState", (int)PlayerAnimationState.Idle);

    }

    // Update is called once per frame
    void Update () {

        //animator.SetInteger("PlayerState", (int)player.playerState);
        SetAnimationState();
        if (player.direction == Direction.Right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (player.direction == Direction.Left)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);

        }

        //Shows sprite with pistol out


        //This also need to go ~Clay
        if (player.isAiming)
        {
            armRotation.SetActive(true);
            
        }
        else
        {
            armRotation.SetActive(false);
        }
    }

    
}
