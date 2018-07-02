using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour {

    PlayerController player;
    Animator animator;
    SpriteRenderer spriteRenderer;
    //Need access to PlayerController Functions to know what the player is doing.
    public GameObject armRotation;
    
    // Use this for initialization
    void Start () {
        player = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetInteger("PlayerState", (int)player.playerState);

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
        if (player.playerState == PlayerState.RangedAttack)
        {
            armRotation.SetActive(true);
            
        }
        else
        {
            armRotation.SetActive(false);
        }
    }

    
}
