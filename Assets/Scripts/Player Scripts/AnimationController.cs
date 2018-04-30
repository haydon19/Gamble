using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour {

    PlayerController player;
    Animator animator;
    SpriteRenderer spriteRenderer;
    //Need access to PlayerController Functions to know what the player is doing.

    // Use this for initialization
    void Start () {
        player = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetInteger("PlayerState", (int)player.playerState);
        if(player.rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        } else if(player.rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;

        }
    }
    
}
